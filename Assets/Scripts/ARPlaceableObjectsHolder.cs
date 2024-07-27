using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ARPlaceableObjectsHolder : MonoBehaviour
{
    [SerializeField] private List<ARObject> arObjects = new();

    void Start()
    {
        if (arObjects.Count == 0)
            return;
        
        arObjects[0].Activate();
    }

    void OnEnable()
    {
        foreach (ARObject o in arObjects)
        {
            o.ReadyToChange += OnARObjectReadyToChange;
        }
    }

    void OnDisable()
    {
        foreach (ARObject o in arObjects)
        {
            o.ReadyToChange -= OnARObjectReadyToChange;
        }
    }

    private void OnARObjectReadyToChange(ARObject arObject)
    {
        var currentIndex = arObjects.IndexOf(arObject);
        var nextIndex = currentIndex + 1;

        if (nextIndex >= arObjects.Count)
            return;

        arObjects[currentIndex].Deactivate();
        arObjects[nextIndex].Activate();
    }
}
