using GameType;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameState _gameState;
    public static GameState GameState
    {
        get => _gameState;

        set
        {
            _gameState = value;

            switch (_gameState)
            {
                case GameState.PREPARE:
                    //Set relevant panel

                    UIManager.Instance.ShowPreparePanel();
                    //UIManager.Instance.ShowMenuPanel();
                    break;
                case GameState.GAME:
                    UIManager.Instance.ShowGamePanel();
                    break;
                case GameState.DEATH_TIMER:
                    UIManager.Instance.OpenDeathTimerPanel();
                    break;
                case GameState.SUCCESS:
                    SUCCESS();
                    break;
                case GameState.FAILED:
                    FAILED();
                    break;
                default:
                    break;
            }
        }
    }

    private static bool _isQuitting;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        GameState = GameState.PREPARE;
    }

    private void Update()
    {
        if (_gameState != GameState.PREPARE || !Input.GetMouseButtonDown(0)) return;

        GameState = GameState.GAME;
    }

    private static void SUCCESS()
    {
        EventManager.Instance.SaveLevelID?.Invoke();
        EventManager.Instance.LevelCompleted?.Invoke();
    }
    private static void FAILED()
    {
        EventManager.Instance.LevelFailed?.Invoke();
    }

    public static void QuitControl(Action targetMethod)
    {
        if (_isQuitting)
        {
            return;
        }

        targetMethod();
    }

    private void OnApplicationQuit()
    {
        _isQuitting = true;
    }
}
