using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ARObject : MonoBehaviour
{
    public event Action<ARObject> ReadyToChange;
    public bool IsActiveByDefault = true;


    void Awake()
    {
        if (IsActiveByDefault)
            Activate();
        else
            Deactivate();
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private protected void OnReadyToChange()
    {
        ReadyToChange?.Invoke(this);
    }
}
