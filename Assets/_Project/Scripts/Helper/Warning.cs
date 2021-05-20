using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class Warning
{
#if UNITY_EDITOR
    public static void ManagerAlreadyExistErrorDisplay(string managerName, bool bunchCall = false)
    {
        string message = bunchCall
            ? $"{managerName} already exist in the scene, you can not add more than one {managerName}! But do not worry mate, I created the other Managers"
            : $"{managerName} already exist in the scene, you can not add more than one {managerName}!";

        EditorUtility.DisplayDialog($"{managerName} already exist in the scene", message, "Ok");
    }

    public static void PanelAlreadyExistErrorDisplay(string panelName, bool bunchWarning = false)
    {
        string message = bunchWarning
            ? $"{panelName} was already exist in the scene, you can not add more than one {panelName}. But do not worry mate, I created the other panels!"
            : $"{panelName} already exist in the scene, you can not add more than one {panelName}!";

        string ok = bunchWarning ? "Oh you scared me bro, thank you!" : "I see";

        EditorUtility.DisplayDialog("Multiple Panel Creation Warning", message, ok);
    }

    public static void UIManagerIsNotExistErrorDisplay()
    {
        EditorUtility.DisplayDialog("UI Manager is not exist!", "You can not add a panel if UI Manager is not exist current scene!", "Okay mate, i will add a UI Manager");
    }
#endif
}
