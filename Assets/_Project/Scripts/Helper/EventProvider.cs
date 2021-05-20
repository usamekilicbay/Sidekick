using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventProvider : MonoBehaviour
{
    #region Unity Methods
    protected virtual void Awake() { Subscribe(); }
    protected virtual void OnDestroy() { GameManager.QuitControl(Unsubscribe); }
    #endregion

    protected abstract void Subscribe();
    protected abstract void Unsubscribe();
}
