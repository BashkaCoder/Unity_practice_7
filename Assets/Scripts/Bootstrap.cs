using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Bootstrap : MonoBehaviour
{
    
    [Header("Player")] 
    [SerializeField] private PlayerSummoner _playerSummoner;
    [SerializeField] private Player _player;
    [SerializeField] private AssetReference PlayerConfig;
    
    [Header("AppView")]
    [SerializeField] private List<InAppPackageView> _inAppPackageViews;
    [SerializeField] private AssetReference AppConfig;

    private void Start()
    {
        var playerConfigHandle = PlayerConfig.LoadAssetAsync<PlayerConfig>();
        playerConfigHandle.Completed += OnPlayerConfigLoaded;
        
        var appConfigHandle= AppConfig.LoadAssetAsync<InAppPackageConfig>();
        appConfigHandle.Completed += OnAppConfigLoaded;
    }

    private void OnPlayerConfigLoaded(AsyncOperationHandle<PlayerConfig> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            _player.Initialize(handle.Result);
            _playerSummoner.SetConfig(handle.Result);
        }
    }
    
    private void OnAppConfigLoaded(AsyncOperationHandle<InAppPackageConfig> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            for (int i = 0; i < _inAppPackageViews.Count; i++)
            {
                _inAppPackageViews[i].Initialize(handle.Result);
            }
        }
    }
}