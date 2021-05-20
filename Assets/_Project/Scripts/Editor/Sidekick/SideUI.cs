using Constants;
using UnityEditor;
using UnityEngine;
using System;
using static Constants.GameObjectName.Canvas;
using static Constants.GameObjectName.Panel;
using static Constants.AssetPath.Prefab;
using static Constants.GameObjectName;

public class SideUI : MonoBehaviour
{
    #region PANEL
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + " All Panels #F8")]
    private static void CreateAllPanels()
    {
        if (!GameObject.Find("UI Manager"))
        {
            DestroyImmediate(GetPanelParent());
            EditorUtility.DisplayDialog("UI Manager is not exist!", "You can not add a panel if UI Manager is not exist current scene", "Okay mate, i will add a UI Manager");

            return;
        }

        CreateGamePanel(true);
        CreateMainMenuPanel(true);
        CreatePreparePanel(true);
        CreateResultPanel(true);
        CreateSettingsPanel(true);
        CreateShopPanel(true);
    }

    #region DEATH TIMER PANEL
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Death Timer Panel")]
    private static void CallCreateDeathTimerPanel() => CreateCreateDeathTimerPanel();

    private static void CreateCreateDeathTimerPanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find("UI Manager"))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(DEATH_TIMER_PANEL))
        {
            Warning.PanelAlreadyExistErrorDisplay(DEATH_TIMER_PANEL, bunchCreated);

            return;
        }

        GameObject deathTimerPanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, DEATH_TIMER_PANEL)));
        SetPanelProperties(deathTimerPanel, DEATH_TIMER_PANEL, "deathTimerPanel", false);
    }
    #endregion

    #region GAME
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Game Panel")]
    private static void CallCreateGamePanel() => CreateGamePanel();

    private static void CreateGamePanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find("UI Manager"))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(GAME_PANEL))
        {
            Warning.PanelAlreadyExistErrorDisplay(GAME_PANEL, bunchCreated);

            return;
        }

        GameObject gamePanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, GAME_PANEL)));
        SetPanelProperties(gamePanel, GAME_PANEL, "gamePanel");
    }
    #endregion

    #region MAIN MENU
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Main Menu Panel")]
    private static void CallCreateMainMenuPanel() => CreateMainMenuPanel();

    private static void CreateMainMenuPanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find("UI Manager"))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(MAIN_MENU_PANEL))
        {
            Warning.PanelAlreadyExistErrorDisplay(MAIN_MENU_PANEL, bunchCreated);

            return;
        }

        GameObject mainMenuPanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, MAIN_MENU_PANEL)));
        SetPanelProperties(mainMenuPanel, MAIN_MENU_PANEL, "mainMenuPanel");
    }
    #endregion

    #region PREPARE
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Prepare Panel")]
    private static void CallCreatePreparePanel() => CreatePreparePanel();

    private static void CreatePreparePanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find("UI Manager"))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(PREPARE_PANEL))
        {
            Warning.PanelAlreadyExistErrorDisplay(PREPARE_PANEL, bunchCreated);

            return;
        }

        GameObject preparePanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, PREPARE_PANEL)));
        SetPanelProperties(preparePanel, PREPARE_PANEL, "preparePanel");
    }
    #endregion

    #region RESULT
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Result Panel")]
    private static void CallCreateResultPanel() => CreateResultPanel();

    private static void CreateResultPanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find("UI Manager"))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(RESULT_PANEL))
        {
            Warning.PanelAlreadyExistErrorDisplay(RESULT_PANEL, bunchCreated);

            return;
        }

        GameObject resultPanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, RESULT_PANEL)));
        SetPanelProperties(resultPanel, RESULT_PANEL, "resultPanel", false);
    }
    #endregion

    #region SETTINGS
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Settings Panel")]
    private static void CallCreateSettingsPanel() => CreateSettingsPanel();

    private static void CreateSettingsPanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find("UI Manager"))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(SETTINGS_PANEL))
        {
            Warning.PanelAlreadyExistErrorDisplay(SETTINGS_PANEL, bunchCreated);

            return;
        }

        GameObject settingsPanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, SETTINGS_PANEL)));
        SetPanelProperties(settingsPanel, SETTINGS_PANEL, "settingsPanel", false);
    }
    #endregion

    #region SHOP
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Shop Panel")]
    private static void CallCreateShopPanel() => CreateSettingsPanel();

    private static void CreateShopPanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find("UI Manager"))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(SHOP_PANEL))
        {
            Warning.PanelAlreadyExistErrorDisplay(SHOP_PANEL, bunchCreated);

            return;
        }

        GameObject shopPanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, SHOP_PANEL)));
        SetPanelProperties(shopPanel, SHOP_PANEL, "shopPanel");
    }
    #endregion

    private static void SetPanelProperties(GameObject panel, string panelName, string propertyName, bool isFullScreenPanel = true)
    {
        panel.name = panelName;
        SetPanelParent(panel);

        panel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        if (isFullScreenPanel)
        {
            panel.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        }

        SerializedObject serializedUIManager = new SerializedObject(GameObject.Find(Manager.UI).GetComponent<UIManager>());
        serializedUIManager.FindProperty(propertyName).objectReferenceValue = panel;
        serializedUIManager.ApplyModifiedProperties();
    }

    #endregion

    #region PARENT

    private static void SetPanelParent(GameObject panel)
    {
        panel.transform.SetParent(GetPanelParent().transform);
    }

    private static GameObject GetPanelParent()
    {
        GameObject canvas = GameObject.FindWithTag("Canvas");

        return canvas ? canvas : CreateEmptyCanvas();
    }

    #endregion

    #region CANVAS

    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Empty Canvas")]
    private static GameObject CreateEmptyCanvas()
    {
        if (IsCanvasExist()) return null;

        GameObject canvas = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(AssetPath.Prefab.CANVAS, EMPTY_CANVAS)));
        canvas.name = GameObjectName.Canvas.CANVAS;

        return canvas;
    }

    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Full Canvas")]
    private static GameObject CreateFullCanvas()
    {
        if (IsCanvasExist()) return null;

        GameObject canvas = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(AssetPath.Prefab.CANVAS, FULL_CANVAS)));
        canvas.name = GameObjectName.Canvas.CANVAS;

        return canvas;
    }

    private static bool IsCanvasExist()
    {
        if (GameObject.Find(GameObjectName.Canvas.CANVAS))
        {
            EditorUtility.DisplayDialog("Warning", "Canvas is already exist in scene", "OK");

            return true;
        }

        return false;
    }

    #endregion
}
