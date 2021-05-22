using Constants;
using UnityEditor;
using UnityEngine;
using static Constants.AssetPath.Prefab;
using static Constants.GameObjectName.Canvas;
using static Constants.GameObjectName;

public class SideUI : MonoBehaviour
{
    #region PANEL
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + " All Panels #F8")]
    private static void CreateAllPanels()
    {
        if (!GameObject.Find(Manager.UI))
        {
            DestroyImmediate(GetPanelParent());
            EditorUtility.DisplayDialog("UI Manager is not exist!", "You can not add a panel if UI Manager is not exist current scene", "Okay mate, i will add a UI Manager");

            return;
        }

        CreateDeathCounterPanel(true);
        CreateGamePanel(true);
        CreateMainMenuPanel(true);
        CreatePreparePanel(true);
        CreateResultPanel(true);
        CreateSettingsPanel(true);
        CreateShopPanel(true);
    }

    #region DEATH COUNTER PANEL
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Death Counter Panel")]
    private static void CallCreateDeathCounterPanel() => CreateDeathCounterPanel();

    private static void CreateDeathCounterPanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find(Manager.UI))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(Panel.DEATH_COUNTER))
        {
            Warning.PanelAlreadyExistErrorDisplay(Panel.DEATH_COUNTER, bunchCreated);

            return;
        }

        GameObject deathCounterPanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, Panel.DEATH_COUNTER)));
        SetPanelProperties(deathCounterPanel, Panel.DEATH_COUNTER, "deathCounterPanel", false);
    }
    #endregion

    #region GAME
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Game Panel")]
    private static void CallCreateGamePanel() => CreateGamePanel();

    private static void CreateGamePanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find(Manager.UI))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(Panel.GAME))
        {
            Warning.PanelAlreadyExistErrorDisplay(Panel.GAME, bunchCreated);

            return;
        }

        GameObject gamePanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, Panel.GAME)));
        SetPanelProperties(gamePanel, Panel.GAME, "gamePanel");
    }
    #endregion

    #region MAIN MENU
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Main Menu Panel")]
    private static void CallCreateMainMenuPanel() => CreateMainMenuPanel();

    private static void CreateMainMenuPanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find(Manager.UI))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(Panel.MAIN_MENU))
        {
            Warning.PanelAlreadyExistErrorDisplay(Panel.MAIN_MENU, bunchCreated);

            return;
        }

        GameObject mainMenuPanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, Panel.MAIN_MENU)));
        SetPanelProperties(mainMenuPanel, Panel.MAIN_MENU, "mainMenuPanel");
    }
    #endregion

    #region PREPARE
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Prepare Panel")]
    private static void CallCreatePreparePanel() => CreatePreparePanel();

    private static void CreatePreparePanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find(Manager.UI))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(Panel.PREPARE))
        {
            Warning.PanelAlreadyExistErrorDisplay(Panel.PREPARE, bunchCreated);

            return;
        }

        GameObject preparePanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, Panel.PREPARE)));
        SetPanelProperties(preparePanel, Panel.PREPARE, "preparePanel");
    }
    #endregion

    #region RESULT
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Result Panel")]
    private static void CallCreateResultPanel() => CreateResultPanel();

    private static void CreateResultPanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find(Manager.UI))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(Panel.RESULT))
        {
            Warning.PanelAlreadyExistErrorDisplay(Panel.RESULT, bunchCreated);

            return;
        }

        GameObject resultPanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, Panel.RESULT)));
        SetPanelProperties(resultPanel, Panel.RESULT, "resultPanel", false);
    }
    #endregion

    #region SETTINGS
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Settings Panel")]
    private static void CallCreateSettingsPanel() => CreateSettingsPanel();

    private static void CreateSettingsPanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find(Manager.UI))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(Panel.SETTINGS))
        {
            Warning.PanelAlreadyExistErrorDisplay(Panel.SETTINGS, bunchCreated);

            return;
        }

        GameObject settingsPanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, Panel.SETTINGS)));
        SetPanelProperties(settingsPanel, Panel.SETTINGS, "settingsPanel", false);
    }
    #endregion

    #region SHOP
    [MenuItem(MenuItemPath.SIDE_UI + MenuItemPath.CREATE + "Shop Panel")]
    private static void CallCreateShopPanel() => CreateSettingsPanel();

    private static void CreateShopPanel(bool bunchCreated = false)
    {
        if (!bunchCreated && !GameObject.Find(Manager.UI))
        {
            Warning.UIManagerIsNotExistErrorDisplay();
            DestroyImmediate(GetPanelParent());

            return;
        }

        if (GameObject.Find(Panel.SHOP))
        {
            Warning.PanelAlreadyExistErrorDisplay(Panel.SHOP, bunchCreated);

            return;
        }

        GameObject shopPanel = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(StringExtension.GetPrefabPath(PANEL, Panel.SHOP)));
        SetPanelProperties(shopPanel, Panel.SHOP, "shopPanel");
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
