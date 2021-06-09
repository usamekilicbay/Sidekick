using Constants;
using SaveMold;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystemManager : EventProvider
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void Subscribe()
    {
        EventManager.Instance.SaveSettings += SaveSettings;
        EventManager.Instance.LoadSettings += LoadSettings;
    }

    protected override void Unsubscribe()
    {
        EventManager.Instance.SaveSettings -= SaveSettings;
        EventManager.Instance.LoadSettings -= LoadSettings;
    }

    #region SETTINGS
    private void SaveSettings(Settings settings)
    {
        string jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(LocalDataPath.SETTINGS, jsonString);

        LoadSettings();
    }

    private void LoadSettings()
    {
        string jsonString = File.ReadAllText(LocalDataPath.SETTINGS);
        Settings settings = JsonUtility.FromJson<Settings>(jsonString);

        EventManager.Instance.UpdateSettings?.Invoke(settings);
    }
    #endregion


}
