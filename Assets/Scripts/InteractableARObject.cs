using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableARObject : ARObject
{
    [SerializeField] private Animation buttonAnimation;
    public void Interact()
    {
        buttonAnimation.Play();
    }

    public void AnimationPlayed()
    {
        OnReadyToChange();
    }
}
