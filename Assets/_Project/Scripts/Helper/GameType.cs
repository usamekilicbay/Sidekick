using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameType 
{
	public enum GameState
	{
		PREPARE,
		GAME,
		DEATH_TIMER,
		SUCCESS,
		FAILED,
	}

    public enum Panel
    {
		DEATH_COUNTER,
		GAME,
		MAIN_MENU,
		PREPARE,
		RESULT,
		SETTINGS,
		SHOP
    }

    public enum ShopTab
    {
		IAP,
		SHOP
    }
}