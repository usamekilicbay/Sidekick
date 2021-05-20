using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : EventProvider
{
	[Header("Health")]
	[SerializeField] private Slider healthBar;
	[SerializeField] private TextMeshProUGUI healthText;

	[Header("Coin")]
	[SerializeField] private TextMeshProUGUI coinText;

	[Header("Score")]
	[SerializeField] private TextMeshProUGUI scoreText;
	
	#region UNITY METHOD

	protected override void Awake()
	{
		base.Awake();
	}

	private void Start()
	{
		Init();
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
		EventManager.Instance.UpdateHealthUI += UpdateHealthUI;
		EventManager.Instance.UpdateCoinText += UpdateCoinText;
		EventManager.Instance.UpdateScoreText += UpdateScoreText;
	}

	protected override void Unsubscribe()
	{
		EventManager.Instance.Restart -= Init;
		EventManager.Instance.UpdateHealthUI -= UpdateHealthUI;
		EventManager.Instance.UpdateCoinText += UpdateCoinText;
		EventManager.Instance.UpdateScoreText -= UpdateScoreText;
	}

	#endregion

	private void Init()
	{
		healthBar.maxValue = 100f;
		healthBar.value = healthBar.maxValue;
	}

	private void UpdateHealthUI(float health)
	{
		healthBar.value = health;
		healthText.SetText($"% {health}");
	}

	private void UpdateCoinText(int coin)
	{
		coinText.SetText(coin.ToString());
	}

	private void UpdateScoreText(int score)
	{
		scoreText.SetText(score.ToString());
	}
}
