using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveMold
{
    [Serializable]
    public struct Profile
    {
        public string userName;
        public int coinCount;
        public int currentLevel; 
        public int highscore; 
        public List<object> ownedItems; 
    }

    [Serializable]
    public struct Settings
    {
        public bool isMusicOpen;
        public bool isSFXOpen;
        public bool isVibrationOpen;
    }
}
