using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mold
{
    [Serializable]
    public class Profile
    {
        public string userName;
        public int coinCount;
        public int currentLevel; 
        public int highscore; 
        public List<object> ownedItems; 
    }

    [Serializable]
    public class Settings
    {
        public bool isMusicOpen;
        public bool isSFXOpen;
        public bool isVibrationOpen;
    }
}
