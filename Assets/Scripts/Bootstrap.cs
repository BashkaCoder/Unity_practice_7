using System;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ConfigsProvider _configsProvider;
    
    [Header("Player")] 
    [SerializeField] private PlayerSummoner _playerSummoner;
    [SerializeField] private Player _player;
    
    [Header("AppView")]
    [SerializeField] private List<InAppPackageView> _inAppPackageViews;

    private void Awake()
    {
        _configsProvider.OnConfigsLoaded += OnConfigsLoaded;
    }

    private void OnDisable()
    {
        _configsProvider.OnConfigsLoaded -= OnConfigsLoaded;
    }

    private void OnConfigsLoaded()
    {
        _player.Initialize(_configsProvider.GetRandomPlayerConfig());
        _playerSummoner.SetConfig(_configsProvider.GetRandomPlayerConfig());

        for (int i = 0; i < _inAppPackageViews.Count; i++)
        {
            _inAppPackageViews[i].Initialize(_configsProvider.GetRandomAppConfig());
        }
    }
}