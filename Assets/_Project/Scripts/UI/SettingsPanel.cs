using SaveMold;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsPanel : EventProvider
{
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Toggle vibrationToggle;

    protected override void Awake()
    {
        base.Awake();

        Init();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void Subscribe()
    {
        EventManager.Instance.UpdateSettings += UpdateSettings;
    }

    protected override void Unsubscribe()
    {
        EventManager.Instance.UpdateSettings -= UpdateSettings;
    }

    private void Init()
    {
        musicToggle.onValueChanged.AddListener(ChangeToggle());
        sfxToggle.onValueChanged.AddListener(ChangeToggle());
        vibrationToggle.onValueChanged.AddListener(ChangeToggle());
    }

    private void UpdateSettings(Settings settings)
    {
        musicToggle.isOn = settings.isMusicOpen;
        sfxToggle.isOn = settings.isSFXOpen;
        vibrationToggle.isOn = settings.isVibrationOpen;
    }


    private UnityAction<bool> ChangeToggle()
    {
        SaveSettings();

        return null;
    }

    private void SaveSettings()
    {
        EventManager.Instance.SaveSettings(new Settings
        {
            isMusicOpen = musicToggle.isOn,
            isSFXOpen = sfxToggle.isOn,
            isVibrationOpen = vibrationToggle.isOn
        });
    }
}
