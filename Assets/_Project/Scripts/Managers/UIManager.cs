using GameType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Panel")]
    [SerializeField] private GameObject deathTimerPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject preparePanel;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject shopPanel;

    public void ShowGamePanel() => PanelChanger(Panel.GAME);

    public void ShowMenuPanel() => PanelChanger(Panel.MENU);

    public void ShowResultPanel() => PanelChanger(Panel.RESULT);

    public void ShowPreparePanel() => PanelChanger(Panel.PREPARE);

    public void ShowSettingsPanel() => PanelChanger(Panel.SETTINGS);

    public void ShowShopPanel() => PanelChanger(Panel.SHOP);

    private void PanelChanger(Panel panel)
    {
        gamePanel.SetActive(panel == Panel.GAME);
        menuPanel.SetActive(panel == Panel.MENU);
        preparePanel.SetActive(panel == Panel.PREPARE);
        resultPanel.SetActive(panel == Panel.RESULT);
        settingsPanel.SetActive(panel == Panel.SETTINGS);
        shopPanel.SetActive(panel == Panel.SHOP);
    }

    public void OpenDeathTimerPanel()
    {
        deathTimerPanel.SetActive(true);
    }
}
