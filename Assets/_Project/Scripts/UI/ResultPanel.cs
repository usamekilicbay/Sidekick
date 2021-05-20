//#define DoTween_Exist
using Constants;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#if DoTween_Exist
//using DG.Tweening;
#endif

public class ResultPanel : EventProvider
{
    [Range(.1f, .5f)]
    [SerializeField] private float animDuration;
    [Space(10)]
    [SerializeField] private RectTransform backgroundRectTransform;

    [Header("Buttons")]
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button watchRewardedAdButton;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private float backgroundStartPosY;

    #region UNITY METHOD

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        PlayInAnim();
    }

    private void Start()
    {
        backgroundStartPosY = backgroundRectTransform.anchoredPosition.y;

        playAgainButton.onClick.AddListener(() => EventManager.Instance.Restart?.Invoke());
        //watchRewardedAdButton.onClick.AddListener(() => EventManager.Instance.SelfReset?.Invoke());
    }

    private void OnDisable()
    {
        PlayOutAnim();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    #endregion

    #region EVENT

    protected override void Subscribe()
    {
        EventManager.Instance.SetResult += SetResult;
    }

    protected override void Unsubscribe()
    {
        EventManager.Instance.SetResult -= SetResult;
    }

    #endregion

    private void SetResult(int score)
    {
        highScoreText.SetText(PlayerPrefs.GetInt(PlayerPrefsKey.HIGH_SCORE).ToString());
        scoreText.SetText(score.ToString());
    }

    #region ANIMATIONS

    private void PlayInAnim()
    {
#if DoTween_Exist
        //backgroundRectTransform.DOAnchorPosY(0, animDuration).SetEase(Ease.InOutBack);
#endif
    }

    private void PlayOutAnim()
    {
#if DoTween_Exist
        //backgroundRectTransform.DOAnchorPosY(backgroundStartPosY, animDuration).SetEase(Ease.InOutBack);
#endif
    }

    #endregion
}
