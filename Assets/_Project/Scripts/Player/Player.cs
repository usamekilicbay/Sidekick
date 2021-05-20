using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : EventProvider
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void Subscribe()
    {
        throw new System.NotImplementedException();
    }

    protected override void Unsubscribe()
    {
        throw new System.NotImplementedException();
    } 

    private void GetHurt()
    {

    }
}
