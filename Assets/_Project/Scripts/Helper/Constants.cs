using UnityEngine;

namespace Constants
{
    public static class Layer
    {
        public const int PLAYER = 8;
        public const int PLATFORM = 9;
        public const int ENEMY = 10;
        public const int TRAP = 11;
        public const int WEAPON = 12;
        public const int MEDKIT = 13;
    }

    public static class PlayerPrefsKey
    {
        public const string LEVEL = "Level";
        public const string HIGH_SCORE = "HighScore";
    }

    public static class ResultMessageConstants
    {
        public const string FAILED = "FAILED";
        public const string COMPLETED = "SUCCES";
    }

    public static class AssetPath
    {
        public static class Prefab
        {
            public const string PREFABS = "Assets/_Project/Prefabs/";
            public const string UI = PREFABS + "UI/";
            public const string PANEL = UI + "Panel/";
            public const string CANVAS = UI + "Canvas/";
        }
    }

    public static class MenuItemPath
    {
        public const string CREATE = "Create/";
        public const string SIDEKICK = "Sidekick/";
        public const string SIDE_MANAGER = "Side Manager/";
        public const string SIDE_SETTINGS = "Side Settings/";
        public const string SIDE_UI = "Side UI/";
    }

    public static class GameObjectName
    {
        public static class Manager
        {
            public const string MANAGER = "Manager";

            public const string ADS = "Ads" + MANAGER;
            public const string AUDIO = "Audio" + MANAGER;
            public const string EVENT = "Event" + MANAGER;
            public const string GAME = "Game" + MANAGER;
            public const string LEVEL = "Level" + MANAGER;
            public const string POOL = "Pool" + MANAGER;
            public const string SCORE = "Score" + MANAGER;
            public const string UI = "UI" + MANAGER;
        }

        public static class Panel
        {
            public const string PANEL = "Panel";

            public const string DEATH_COUNTER = "DeathCounter" + PANEL;
            public const string GAME = "Game" + PANEL;
            public const string MAIN_MENU = "MainMenu" + PANEL;
            public const string PREPARE = "Prepare" + PANEL;
            public const string RESULT = "Result" + PANEL;
            public const string SETTINGS = "Settings" + PANEL;
            public const string SHOP = "Shop" + PANEL;
        }

        public static class Canvas
        {
            public const string CANVAS = "Canvas";
            public const string EMPTY_CANVAS = "EmptyCanvas";
            public const string FULL_CANVAS = "FullCanvas";
        }
    }

    public static class FileExtension
    {
        public const string ASSET = ".asset";
        public const string PREFAB = ".prefab";
        public const string MP3 = ".mp3";
        public const string MP4 = ".mp4";
        public const string PNG = ".png";
    }

    public static class AdPlacement
    {
        public const string INTERSTITIAL = "interstitial";
        public const string REWARDED = "rewarded";
    }

    public static class LocalDataPath
    {
        public static readonly string SAVE = Application.persistentDataPath + "/SAVE/";
        public static readonly string CONSUMABLES = SAVE + "Consumables/";
        public static readonly string INVENTORY = SAVE + "Inventory/";
        public static readonly string PROGRESS = SAVE + "Progress/";
        public static readonly string SETTINGS = SAVE + "Settings/";
    }
}
