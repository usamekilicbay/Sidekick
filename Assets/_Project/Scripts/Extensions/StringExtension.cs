using Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringExtension : MonoBehaviour
{
    public static string GetPrefabPath(string prefabFolder,string prefabName)
    {
        return $"{prefabFolder}{prefabName}{FileExtension.PREFAB}";
    }
}
