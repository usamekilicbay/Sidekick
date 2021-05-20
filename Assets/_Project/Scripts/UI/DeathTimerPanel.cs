using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathTimerPanel : EventProvider
{
    [SerializeField] private float timeLimit;
    [SerializeField] private float timer;

    [Header("Button")]
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button watchRewardedVideoAdButton;
    [SerializeField] private Button playAgainButton;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI messageText;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    private void OnEnable()
    {
        SelfReset();
    }

    private void Update()
    {
        CountdownTimer();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

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

    private void Init()
    {
        mainMenuButton.onClick.AddListener(ShowMainMenu);
        playAgainButton.onClick.AddListener(PlayAgain);
        watchRewardedVideoAdButton.onClick.AddListener(WatchRewardedVideoAd);
    }

    private void SelfReset()
    {
        timer = timeLimit;
        watchRewardedVideoAdButton.image.fillAmount = 1;
        watchRewardedVideoAdButton.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(false);
    }

    private void CountdownTimer()
    {
        timer -= Time.deltaTime;

        watchRewardedVideoAdButton.image.fillAmount = timer * timeLimit;

        if (timer > 0) return;

        ChangeActiveButton();
    }

    private void ChangeActiveButton()
    {
        watchRewardedVideoAdButton.gameObject.SetActive(false);
        playAgainButton.gameObject.SetActive(true);
    }

    private void ShowMainMenu()
    {
        gameObject.SetActive(false);
    }

    private void WatchRewardedVideoAd()
    {
        EventManager.Instance.ShowRewardedAd?.Invoke();
        gameObject.SetActive(false);
    }

    private void PlayAgain()
    {
        EventManager.Instance.Restart?.Invoke();
        gameObject.SetActive(false);
    }
}
