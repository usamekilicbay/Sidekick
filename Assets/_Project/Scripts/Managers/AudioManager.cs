using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : EventProvider
{
    [SerializeField] private AudioSource audioSource;

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
        EventManager.Instance.PlaySFX += PlaySFX;
    }

    protected override void Unsubscribe()
    {
        EventManager.Instance.PlaySFX -= PlaySFX;
    }
   
    #endregion

    private void PlaySFX(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
 
}
