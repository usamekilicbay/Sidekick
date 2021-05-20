using Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SideSettings : MonoBehaviour
{
    [MenuItem(MenuItemPath.SIDE_SETTINGS + "Set Landscape Debug")]
    private static void SetLandscapeDebug()
    {
        PlayerSettings.companyName = "Orenda";
        PlayerSettings.colorSpace = ColorSpace.Gamma;
        SetOrientationLandscape();
        SetScriptingBackendMono();
    }

    [MenuItem(MenuItemPath.SIDE_SETTINGS + "Set Landscape Release #F5")]
    private static void SetLandscapeRelease()
    {
        PlayerSettings.companyName = "Orenda";
        PlayerSettings.colorSpace = ColorSpace.Linear;
        SetOrientationLandscape();
        SetScriptingBackendIL2CPP();
    }

    [MenuItem(MenuItemPath.SIDE_SETTINGS + "Set Portrait Debug")]
    private static void SetPortraitDebug()
    {
        PlayerSettings.companyName = "Orenda";
        PlayerSettings.colorSpace = ColorSpace.Gamma;
        SetOrientationPortrait();
        SetScriptingBackendMono();
    }

    [MenuItem(MenuItemPath.SIDE_SETTINGS + "Set Portrait Release #F6")]
    private static void SetPortraitRelease()
    {
        PlayerSettings.companyName = "Orenda";
        PlayerSettings.colorSpace = ColorSpace.Linear;
        SetOrientationPortrait();
        SetScriptingBackendIL2CPP();
    }

    [MenuItem(MenuItemPath.SIDE_SETTINGS + "Set Orientation Portrait")]
    private static void SetOrientationPortrait()
    {
        PlayerSettings.defaultInterfaceOrientation = UIOrientation.Portrait;
    }

    [MenuItem(MenuItemPath.SIDE_SETTINGS + "Set Orientation Landscape")]
    private static void SetOrientationLandscape()
    {
        PlayerSettings.defaultInterfaceOrientation = UIOrientation.AutoRotation;
        PlayerSettings.allowedAutorotateToPortrait = false;
        PlayerSettings.allowedAutorotateToPortraitUpsideDown = false;
    }

    [MenuItem(MenuItemPath.SIDE_SETTINGS + "Set Scripting Backend MONO")]
    private static void SetScriptingBackendMono()
    {
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.Mono2x);
        PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Android, ApiCompatibilityLevel.NET_Standard_2_0);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARMv7;
    }

    [MenuItem(MenuItemPath.SIDE_SETTINGS + "Set Scripting Backend IL2CPP")]
    private static void SetScriptingBackendIL2CPP()
    {
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Android, ApiCompatibilityLevel.NET_4_6);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.All;
    }
}
