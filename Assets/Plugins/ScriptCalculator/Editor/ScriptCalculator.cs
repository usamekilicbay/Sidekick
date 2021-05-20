#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class ScriptCalculator : EditorWindow
{
    #region Variables

    public static EditorWindow window;

    private string searchInDirectoryText = "";
    private bool searchInDirectory = false;
    private bool scriptExtensionsCS = true;
    private bool scriptExtensionsJS = true;
    private bool includeUnityPackages = false;
    private bool passBlankLines = false;
    private bool isFoldoutFilesArea = false;
    private Vector2 scrollPos = Vector2.zero;
    private int scriptCount = -1;
    private int totalLineCount = -1;
    private List<string> fileNames = new List<string>();
    #endregion

    #region For Init Window
    [MenuItem("Tools/Script And Code Line Calculator %t")]
    static void Init()
    {
        if (window != null)
            window.Close();

        window = CreateInstance<ScriptCalculator>();
        window.wantsMouseMove = false;
        window.position = new Rect(Screen.width, Screen.height / 2, 320, 380);
        CenterOnMainWin(window);
        window.ShowPopup();
    }
    #endregion

    #region For Draw the Window
    private void OnGUI()
    {
        var style = new GUIStyle();
        style.fontStyle = FontStyle.Bold;
        style.alignment = TextAnchor.MiddleCenter;

        var style2 = new GUIStyle();
        style2.alignment = TextAnchor.MiddleCenter;

        EditorGUILayout.BeginHorizontal(GUI.skin.box);
        EditorGUILayout.LabelField("Script And Code Line Calculator", style);
        if (GUILayout.Button("X", GUILayout.Width(25)))
        {
            this.Close();
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        searchInDirectory = EditorGUILayout.Toggle("Search In Directory ?", searchInDirectory);
        if (searchInDirectory)
        {
            EditorGUI.indentLevel++;
            float labelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 185f;
            searchInDirectoryText = EditorGUILayout.TextField("Search In (E.g. Assets/Scripts): ", searchInDirectoryText);
            EditorGUIUtility.labelWidth = labelWidth;
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.BeginVertical();
        //EditorGUILayout.Space();
        scriptExtensionsCS = EditorGUILayout.ToggleLeft("CS", scriptExtensionsCS);
        scriptExtensionsJS = EditorGUILayout.ToggleLeft("JS", scriptExtensionsJS);
        includeUnityPackages = EditorGUILayout.ToggleLeft("Include unity packages", includeUnityPackages);
        passBlankLines = EditorGUILayout.ToggleLeft("Pass the blank lines", passBlankLines);
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical(style2);

        if (GUILayout.Button("Search", GUILayout.Width(290)))
        {
            isFoldoutFilesArea = false;
            fileNames.Clear();
            scriptCount = 0;
            totalLineCount = 0;

            if (!scriptExtensionsJS && !scriptExtensionsCS)
            {
                EditorUtility.DisplayDialog("Error", "You must to choose at least one script type", "OK");
                return;
            }

            int assetCount = AssetDatabase.FindAssets("t:Script").Length;

            for (int i = 0; i < assetCount; i++)
            {
                float progreassValue = 1f / (float)assetCount;
                EditorUtility.DisplayProgressBar("Please Wait", "Calculating...", progreassValue);

                string file = AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("t:Script")[i]);
                bool add = false;

                if (!includeUnityPackages && file.StartsWith("Packages/"))
                {
                    add = false;
                }
                else
                {
                    if (searchInDirectory && searchInDirectoryText.Length > 0)
                    {
                        if ((file.ToLower().Contains("/" + searchInDirectoryText.ToLower()) ||
                            file.ToLower().Contains(searchInDirectoryText.ToLower() + "/")) &&
                            ((scriptExtensionsCS && (file.Substring(file.Length - 3).ToLower() == ".cs")) ||
                            (scriptExtensionsJS && (file.Substring(file.Length - 3).ToLower() == ".js"))))
                        {
                            add = true;
                        }
                    }
                    else
                    {
                        if ((scriptExtensionsCS && (file.Substring(file.Length - 3).ToLower() == ".cs")) ||
                            (scriptExtensionsJS && (file.Substring(file.Length - 3).ToLower() == ".js")))
                        {
                            add = true;
                        }
                    }
                }

                if (add)
                {
                    scriptCount++;

                    TextAsset textAsset = (TextAsset)AssetDatabase.LoadAssetAtPath(file, typeof(TextAsset));
                    fileNames.Add(file);

                    if (passBlankLines)
                    {
                        string[] lines = textAsset.text.Split('\n');
                        totalLineCount += lines.Count(line => (line.Any(char.IsLetterOrDigit)));
                    }
                    else
                    {
                        totalLineCount += textAsset.text.Split('\n').Length;
                    }
                }
            }
            EditorUtility.ClearProgressBar();

            if (scriptCount == 0)
            {
                EditorUtility.DisplayDialog("Info", "There were no results", "Ok");
            }

        }

        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();
        EditorGUILayout.HelpBox("Script Count : " + (scriptCount == -1 ? "Not calculated (Press Search)" : scriptCount.ToString()), MessageType.Info);
        EditorGUILayout.HelpBox("Total Line Count : " + (totalLineCount == -1 ? "Not calculated (Press Search)" : totalLineCount.ToString()), MessageType.Info);

        EditorGUILayout.Space();

        isFoldoutFilesArea = EditorGUILayout.Foldout(isFoldoutFilesArea, "Files");

        if (isFoldoutFilesArea)
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

            if (fileNames.Count > 0)
            {
                for (int i = 0; i < fileNames.Count; i++)
                {
                    EditorGUILayout.LabelField(i.ToString() + "- " + fileNames[i], GUILayout.Width(700));
                }
            }
            else
            {
                EditorGUILayout.LabelField("There were no results", GUILayout.Width(130));
            }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();

        }
    }
    #endregion

    #region For Center the Window
    private static void CenterOnMainWin(EditorWindow aWin)
    {
        var main = GetEditorMainWindowPos();
        var pos = aWin.position;
        float w = (main.width - pos.width) * 0.5f;
        float h = (main.height - pos.height) * 0.5f;
        pos.x = main.x + w;
        pos.y = main.y + h + ((-150 * Screen.currentResolution.height) / 1080f);
        aWin.position = pos;
    }

    private static Rect GetEditorMainWindowPos()
    {
        var containerWinType = GetAllDerivedTypes().Where(t => t.Name == "ContainerWindow").FirstOrDefault();

        if (containerWinType == null)
            throw new System.MissingMemberException("Can't find internal type ContainerWindow. Maybe something has changed inside Unity");
        var showModeField = containerWinType.GetField("m_ShowMode", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var positionProperty = containerWinType.GetProperty("position", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        if (showModeField == null || positionProperty == null)
            throw new System.MissingFieldException("Can't find internal fields 'm_ShowMode' or 'position'. Maybe something has changed inside Unity");
        var windows = Resources.FindObjectsOfTypeAll(containerWinType);
        foreach (var win in windows)
        {
            var showmode = (int)showModeField.GetValue(win);
            if (showmode == 4) // main window
            {
                var pos = (Rect)positionProperty.GetValue(win, null);
                return pos;
            }
        }
        throw new System.NotSupportedException("Can't find internal main window. Maybe something has changed inside Unity");
    }

    private static System.Type[] GetAllDerivedTypes()
    {
        var result = new List<System.Type>();
        var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
        System.Type aType = typeof(ScriptableObject);


        foreach (var assembly in assemblies)
        {
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.IsSubclassOf(aType))
                    result.Add(type);
            }
        }
        return result.ToArray();
    }
    #endregion
}
#endif