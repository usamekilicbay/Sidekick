using SaveMold;
using System;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : Singleton<EventManager>
{
    #region MAIN
    public Action StartGame;
    public Action Restart;
    public Action GameOver;
    #endregion

    #region GAME
    public Action MainAction;
    public Action GetHurt;
    public Action Heal;
    public Action CollectCoin;
    #endregion

    #region SCORE
    public Action<int> UpdateScore;
    public Action SaveHighscore;
    public Action LoadHighscore;
    #endregion

    #region UI
    public Action UpdateLevelText;
    public Action<float> UpdateHealthUI;
    public Action<int> UpdateCoinText;
    public Action<int> UpdateScoreText;
    public Action<int> SetResult;
    #endregion

    #region SFX
    public Action<AudioClip> PlaySFX;
    #endregion

    #region LEVEL
    public Func<int> GetSavedLevelID;
    public Action SaveLevelID;
    public Action PrepareNewLevel;
    #endregion

    #region RESULT
    public Action LevelFailed;
    public Action LevelCompleted;
    #endregion

    #region POOL	
    public Action<Transform> RespawnItem;
    #endregion

    #region ADS
    public Action ShowRewardedAd;
    #endregion


    #region SAVE
    public Action<Settings> SaveSettings;
    public Action LoadSettings;
    public Action<Settings> UpdateSettings;
    #endregion
}