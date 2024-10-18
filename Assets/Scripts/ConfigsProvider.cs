using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class ConfigsProvider : MonoBehaviour
{
    private readonly Dictionary<string, List<ScriptableObject>> _configs = new();
    public event Action OnConfigsLoaded;

    private async void Awake()
    {
        await UniTask.WhenAll(
            LoadConfigsByLabel<PlayerConfig>("Player Config"),
            LoadConfigsByLabel<InAppPackageConfig>("App Config")
            );
        
        OnConfigsLoaded?.Invoke();
    }
    
    private async UniTask LoadConfigsByLabel<T>(string label) where T : ScriptableObject
    {
        var handle = Addressables.LoadAssetsAsync<T>(label, null);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            if (!_configs.ContainsKey(label))
            {
                _configs[label] = new List<ScriptableObject>();
            }

            foreach (var config in handle.Result)
            {
                _configs[label].Add(config);
            }
        }
        else
        {
            Debug.LogError($"Failed to load assets with label: {label}");
        }
    }

    public PlayerConfig GetRandomPlayerConfig()
    {
        if (ConfigPresented("Player Config"))
        {
            return (PlayerConfig) _configs["Player Config"][UnityEngine.Random.Range(0, _configs["Player Config"].Count)];
        }

        Debug.LogError("No Player Configs found");
        return null;
    }

    public InAppPackageConfig GetRandomAppConfig()
    {
        if (ConfigPresented("App Config"))
        {
            return (InAppPackageConfig) _configs["App Config"][UnityEngine.Random.Range(0, _configs["App Config"].Count)];
        }

        Debug.LogError("No App Configs found");
        return null;
    }

    private bool ConfigPresented(string key)
    {
        return _configs.ContainsKey(key) && _configs[key].Count > 0;
    }
}