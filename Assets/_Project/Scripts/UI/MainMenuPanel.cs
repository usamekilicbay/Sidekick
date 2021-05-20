using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : EventProvider
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button rateUsButton;
    [SerializeField] private Button leaderboardButton;


    #region UNITY METHODS
    protected override void Awake()
    {
        base.Awake();

        ButtonAddListenerInit();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
    #endregion

    #region EVENT
    protected override void Subscribe()
    {
        throw new System.NotImplementedException();
    }

    protected override void Unsubscribe()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    private void ButtonAddListenerInit()
    {
        playButton.onClick.AddListener(Play);
        settingsButton.onClick.AddListener(OpenSettingsPanel);
        shopButton.onClick.AddListener(OpenShopPanel);
        rateUsButton.onClick.AddListener(RateUs);
        leaderboardButton.onClick.AddListener(ShowLeaderBoard);
    }

    private void Play()
    {
        EventManager.Instance.StartGame?.Invoke();
    }

    private void OpenSettingsPanel()
    {
        UIManager.Instance.ShowSettingsPanel();
    }

    private void OpenShopPanel()
    {
        UIManager.Instance.ShowShopPanel();
    }
    
    private void RateUs()
    {
        throw new NotImplementedException();
    }

    private void ShowLeaderBoard()
    {
        throw new NotImplementedException();
    }
}
