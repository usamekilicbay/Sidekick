using Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Constants.GameObjectName;

public class SideManager : MonoBehaviour
{
    [MenuItem(MenuItemPath.SIDE_MANAGER + MenuItemPath.CREATE + "All Managers #F7")]
    private static void CreateAllManagers()
    {
        CreateAudioManager(true);
        CreateEventManager(true);
        CreateGameManager(true);
        CreateLevelManager(true);
        CreatePoolManager(true);
        CreateScoreManager(true);
        CreateUIManager(true);
    }

    #region ADS
    [MenuItem(MenuItemPath.SIDE_MANAGER + MenuItemPath.CREATE + "Ads Manager")]
    private static void CallCreateAdsManager() => CreateAdsManager();

    private static void CreateAdsManager(bool bunchCall = false)
    {
        if (GameObject.Find(Manager.ADS))
        {
            Warning.ManagerAlreadyExistErrorDisplay(Manager.ADS, bunchCall);

            return;
        }

        GameObject adsManager = new GameObject(Manager.ADS, typeof(AdsManager), typeof(AudioSource));
        SetParent(adsManager);
    }
    #endregion

    #region AUDIO
    [MenuItem(MenuItemPath.SIDE_MANAGER + MenuItemPath.CREATE + "Audio Manager")]
    private static void CallCreateAudioManager() => CreateAudioManager();

    private static void CreateAudioManager(bool bunchCall = false)
    {
        if (GameObject.Find(Manager.AUDIO))
        {
            Warning.ManagerAlreadyExistErrorDisplay(Manager.AUDIO, bunchCall);

            return;
        }

        GameObject audioManager = new GameObject(Manager.AUDIO, typeof(AudioManager), typeof(AudioSource));
        SetParent(audioManager);

        SerializedObject serializedAudioManager = new SerializedObject(audioManager.GetComponent<AudioManager>());
        serializedAudioManager.FindProperty("audioSource").objectReferenceValue = audioManager.GetComponent<AudioSource>();
        serializedAudioManager.ApplyModifiedProperties();
    }
    #endregion

    #region EVENT
    [MenuItem(MenuItemPath.SIDE_MANAGER + MenuItemPath.CREATE + "Event Manager")]
    private static void CallCreateEventManager() => CreateEventManager();

    private static void CreateEventManager(bool bunchCall = false)
    {
        if (GameObject.Find(Manager.EVENT))
        {
            Warning.ManagerAlreadyExistErrorDisplay(Manager.EVENT, bunchCall);

            return;
        }

        GameObject eventManager = new GameObject(Manager.EVENT, typeof(EventManager));
        SetParent(eventManager);
    }
    #endregion

    #region GAME
    [MenuItem(MenuItemPath.SIDE_MANAGER + MenuItemPath.CREATE + "Game Manager")]
    private static void CallCreateGameManager() => CreateGameManager();

    private static void CreateGameManager(bool bunchCall = false)
    {
        if (GameObject.Find(Manager.GAME))
        {
            Warning.ManagerAlreadyExistErrorDisplay(Manager.GAME, bunchCall);

            return;
        }

        GameObject gameManager = new GameObject("Game Manager", typeof(GameManager));
        SetParent(gameManager);
    }
    #endregion

    #region LEVEL
    [MenuItem(MenuItemPath.SIDE_MANAGER + MenuItemPath.CREATE + "Level Manager")]
    private static void CallCreateLevelManager() => CreateLevelManager();

    private static void CreateLevelManager(bool bunchCall = false)
    {
        if (GameObject.Find(Manager.LEVEL))
        {
            Warning.ManagerAlreadyExistErrorDisplay(Manager.LEVEL, bunchCall);

            return;
        }

        GameObject levelManager = new GameObject(Manager.LEVEL, typeof(LevelManager));
        SetParent(levelManager);
    }
    #endregion

    #region POOL
    [MenuItem(MenuItemPath.SIDE_MANAGER + MenuItemPath.CREATE + "Pool Manager")]
    private static void CallCreatePoolManager() => CreatePoolManager();

    private static void CreatePoolManager(bool bunchCall = false)
    {
        if (GameObject.Find(Manager.POOL))
        {
            Warning.ManagerAlreadyExistErrorDisplay(Manager.POOL, bunchCall);

            return;
        }

        GameObject poolManager = new GameObject(Manager.POOL, typeof(PoolManagerBase));
        SetParent(poolManager);
    }
    #endregion

    #region SCORE
    [MenuItem(MenuItemPath.SIDE_MANAGER + MenuItemPath.CREATE + "Score Manager")]
    private static void CallCreateScoreManager() => CreateScoreManager();

    private static void CreateScoreManager(bool bunchCall = false)
    {
        if (GameObject.Find(Manager.SCORE))
        {
            Warning.ManagerAlreadyExistErrorDisplay(Manager.SCORE, bunchCall);

            return;
        }

        GameObject scoreManager = new GameObject(Manager.SCORE, typeof(ScoreManager));
        SetParent(scoreManager);
    }
    #endregion

    #region UI
    [MenuItem(MenuItemPath.SIDE_MANAGER + MenuItemPath.CREATE + "UI Manager")]
    private static void CallCreateUIManager() => CreateUIManager();

    private static void CreateUIManager(bool bunchCall = false)
    {
        if (GameObject.Find(Manager.UI))
        {
            Warning.ManagerAlreadyExistErrorDisplay(Manager.UI, bunchCall);

            return;
        }

        GameObject uiManager = new GameObject(Manager.UI, typeof(UIManager));
        SetParent(uiManager);
    }
    #endregion

    private static void SetParent(GameObject manager)
    {
        manager.transform.SetParent(GetParent());
    }

    private static Transform GetParent()
    {
        GameObject managerParent = GameObject.Find("MANAGERS");

        return managerParent ? managerParent.transform : new GameObject("MANAGERS").transform;
    }
}
