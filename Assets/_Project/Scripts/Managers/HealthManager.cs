using GameType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private float health;

    public float Health
    {
        get => health;
        set
        {
            health = value;
            if (health <= 0)
            {
                GameManager.GameState = GameState.DEATH_TIMER;
            }
        }
    }
}
