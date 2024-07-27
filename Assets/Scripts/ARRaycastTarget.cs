using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARRaycastTarget : MonoBehaviour
{
    [SerializeField] private ARRaycastManager aRRaycastManager;
    [SerializeField] private Camera arCamera;
    private List<ARRaycastHit> m_RaycastHit = new();

    void Update()
    {
        Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (aRRaycastManager.Raycast(ray, m_RaycastHit, UnityEngine.XR.ARSubsystems.TrackableType.AllTypes))
            {
                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.collider.gameObject.TryGetComponent<InteractableARObject>(out var interactableARObject))
                    {
                        interactableARObject.Interact();
                    }
                }
            }
        }
    }
}
