using GameType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Panels")]
    [SerializeField] private GameObject deathCounterPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject preparePanel;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject shopPanel;

    public void ShowDeathCounterPanel() => PanelChanger(Panel.DEATH_COUNTER);
    
    public void ShowGamePanel() => PanelChanger(Panel.GAME);

    public void ShowMenuPanel() => PanelChanger(Panel.MAIN_MENU);

    public void ShowPreparePanel() => PanelChanger(Panel.PREPARE);

    public void ShowResultPanel() => PanelChanger(Panel.RESULT);

    public void ShowSettingsPanel() => PanelChanger(Panel.SETTINGS);

    public void ShowShopPanel() => PanelChanger(Panel.SHOP);

    private void PanelChanger(Panel panel)
    {
        deathCounterPanel.SetActive(panel == Panel.DEATH_COUNTER);
        gamePanel.SetActive(panel == Panel.GAME);
        mainMenuPanel.SetActive(panel == Panel.MAIN_MENU);
        preparePanel.SetActive(panel == Panel.PREPARE);
        resultPanel.SetActive(panel == Panel.RESULT);
        settingsPanel.SetActive(panel == Panel.SETTINGS);
        shopPanel.SetActive(panel == Panel.SHOP);
    }
}
