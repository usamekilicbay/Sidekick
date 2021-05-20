using Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : EventProvider
{
	[Range(1, 100)]
	[SerializeField] private int coinScoreMultiplier;

	private int _coinCount;
	private int _score;

	#region UNITY METHOD
	
	protected override void Awake()
	{
		base.Awake();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}

	#endregion

	#region EVENT

	protected override void Subscribe()
	{
		EventManager.Instance.Restart += Init;
		EventManager.Instance.UpdateScore += UpdateScore;
		EventManager.Instance.CollectCoin += CollectCoin;
		EventManager.Instance.GameOver += SetHighScore;
	}

	protected override void Unsubscribe()
	{
		EventManager.Instance.Restart -= Init;
		EventManager.Instance.UpdateScore -= UpdateScore;
		EventManager.Instance.CollectCoin -= CollectCoin;
		EventManager.Instance.GameOver -= SetHighScore;
	}

	#endregion

	private void Init()
	{
		_score = 0;
		_coinCount = 0;
	}

	private void UpdateScore(int progress)
	{
		_score = progress;

		EventManager.Instance.UpdateScore?.Invoke(_score);
	}

	private void CollectCoin()
	{
		_coinCount++;
	}

	private void SetHighScore()
	{
		_score = CalculateLastScore();
		EventManager.Instance.SetResult?.Invoke(_score);

		if (!CheckHighScore()) return;

		PlayerPrefs.SetInt(PlayerPrefsKey.HIGH_SCORE, _score);
		EventManager.Instance.SetResult?.Invoke(_score);
	}

	private int CalculateLastScore()
	{
		return _score += _coinCount * coinScoreMultiplier;
	}

	private bool CheckHighScore()
	{
		return !PlayerPrefs.HasKey(PlayerPrefsKey.HIGH_SCORE) || _score > PlayerPrefs.GetInt(PlayerPrefsKey.HIGH_SCORE);
	}
}
