using Constants;
using UnityEngine;

public class LevelManager : EventProvider
{
    [SerializeField] private LevelContainer levelContainer;
    [SerializeField] private GameObject currentLevel;

    #region UNITY METHOD

    protected override void Awake()
    {
        base.Awake();
        ClearLevel();
        LoadLevel();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    #endregion

    #region EVENT

    protected override void Subscribe()
    {
        EventManager.Instance.PrepareNewLevel += PrepareNewLevel;
        EventManager.Instance.GetSavedLevelID += GetSavedLevelID;
        EventManager.Instance.SaveLevelID += SaveLevelID;
    }

    protected override void Unsubscribe()
    {
        EventManager.Instance.PrepareNewLevel += PrepareNewLevel;
        EventManager.Instance.GetSavedLevelID -= GetSavedLevelID;
        EventManager.Instance.SaveLevelID -= SaveLevelID;
    }

    #endregion

    private void PrepareNewLevel()
    {
        ClearLevel();
        LoadLevel();
    }

    private void LoadLevel()
    {
        currentLevel = Instantiate(levelContainer.levels[GetSavedLevelID()]);
    }

    private void ClearLevel()
    {
        if (currentLevel == null || System.Array.IndexOf(levelContainer.levels, currentLevel) == 0)
            return;

        Destroy(currentLevel);
    }

    private int GetSavedLevelID()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsKey.LEVEL)) return 1;

        return PlayerPrefs.GetInt(PlayerPrefsKey.LEVEL);
    }

    private void SaveLevelID()
    {
        PlayerPrefs.SetInt(PlayerPrefsKey.LEVEL, GetSavedLevelID() + 1);
    }
}
