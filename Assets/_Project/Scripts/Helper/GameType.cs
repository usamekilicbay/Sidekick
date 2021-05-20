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
		GAME,
		MENU,
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