using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private OBJInteract interactedObj;

    [SerializeField] private KeyCode interactwithObj = KeyCode.Mouse0;

    [SerializeField] private Image crosshair = null;
    private bool isCrossHairActive;
    private bool doOnce;

    private const string interactableTag = "Interactable";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if(hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    interactedObj = hit.collider.gameObject.GetComponent<OBJInteract>();
                    CrosshairChange(true);
                    interactedObj.GlowObj();
                }

                isCrossHairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactwithObj))
                {
                    //Add if statements here to pick objects
                    interactedObj.RotateOBJ();
                }
            }
        }

        else
        {
            if(isCrossHairActive)
            {
                CrosshairChange(false);
                doOnce = false;
                interactedObj.ResetMat();
            }
        }
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrossHairActive = false;
        }
    }
}
