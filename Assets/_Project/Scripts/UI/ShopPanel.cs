using DG.Tweening;
using GameType;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [Header("Anim Settings")]
    [Range(.5f, 1f)] [SerializeField] private float colorChangeDuration;

    [Header("Color")]
    [SerializeField] private Color iapTabColor;
    [SerializeField] private Color shopTabColor;

    [Header("Image")]
    [SerializeField] private Image shopPanelBackground;

    [Header("Tab")]
    [SerializeField] private GameObject iapTab;
    [SerializeField] private GameObject shopTab;

    [Header("Button")]
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button iapTabButton;
    [SerializeField] private Button shopTabButton;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        mainMenuButton.onClick.AddListener(ShowMainMenu);
        shopTabButton.onClick.AddListener(ShowShopTab);
        iapTabButton.onClick.AddListener(ShowIAPTab);

        ShowShopTab();
    }

    private void ShowMainMenu()
    {
        throw new NotImplementedException();
    }

    private void ShowIAPTab()
    {
        shopPanelBackground.DOColor(iapTabColor, colorChangeDuration);
        TabChanger(ShopTab.IAP);
    }

    private void ShowShopTab()
    {
        shopPanelBackground.DOColor(shopTabColor, colorChangeDuration);
        TabChanger(ShopTab.SHOP);
    }

    private void TabChanger(ShopTab tab)
    {
        iapTab.SetActive(ShopTab.IAP == tab);
        shopTab.SetActive(ShopTab.SHOP == tab);
    }
}
