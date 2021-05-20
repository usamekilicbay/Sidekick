using Constants;
using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Sidekick : MonoBehaviour
{
    /// <summary>
    /// % = Ctrl
    /// & = Alt
    /// # = Shift
    /// </summary>

    #region EDITOR

    [MenuItem("Sidekick/Editor/Clear Console %q")] // CTRL + Q
    private static void ClearConsole()
    {
        Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
        Type type = assembly.GetType("UnityEditor.LogEntries");
        MethodInfo method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }


    [MenuItem("Sidekick/Editor/Delete All Player Prefs #F9")] // CTRL + U
    private static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }


    [MenuItem("Sidekick/Editor/Toggle Inspector Lock #F12")] // SHIFT + F12
    private static void ToggleInspectorLock()
    {
        ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
        ActiveEditorTracker.sharedTracker.ForceRebuild();
    }

    #endregion

    #region CREATE

    [MenuItem("Sidekick/Create/Level Container")]
    private static void CreateLevelContainer()
    {
        LevelContainer levelContainer = AssetDatabase.LoadAssetAtPath("Assets/_Project/Datas/Level/LevelContainer.asset", typeof(LevelContainer)) as LevelContainer;

        if (levelContainer == null)
        {
            levelContainer = ScriptableObject.CreateInstance<LevelContainer>();

            AssetDatabase.CreateAsset(levelContainer, "Assets/_Project/Datas/Level/LevelContainer.asset");
            AssetDatabase.SaveAssets();

            Debug.Log("LevelContainer is created");
        }
        else
            Debug.LogWarning("LevelContainer is already Exist");

        LevelManager levelManager = FindObjectOfType<LevelManager>();
        SerializedObject serializedLevelManager = new SerializedObject(levelManager);
        serializedLevelManager.FindProperty("levelContainer").objectReferenceValue = levelContainer;
        serializedLevelManager.ApplyModifiedProperties();

        Selection.activeObject = levelContainer;
        EditorUtility.FocusProjectWindow();
        Selection.activeGameObject = levelManager.gameObject;
    }

    #endregion
}
