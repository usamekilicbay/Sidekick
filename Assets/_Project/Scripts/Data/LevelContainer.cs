using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Level Container", fileName = "LevelContainer")]
public class LevelContainer : ScriptableObject
{
    public GameObject[] levels;
}
