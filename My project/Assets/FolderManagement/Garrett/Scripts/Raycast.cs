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

    public bool clickCooldown = false;

    private const string interactableTag = "Interactable";
    private const string pillarTag = "Pillar";
    private const string pillarTag2 = "Pillar2";
    private const string pillarTag3 = "Pillar3";
    private const string pillarTag4 = "Pillar4";
    private const string pillarTag5 = "Pillar5";
    private const string pillarTag6 = "Pillar6";

    public bool seeing;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask) && !clickCooldown)
        {
            //// TELESCOPE ////

            if (hit.collider.CompareTag(interactableTag))
            {
                seeing = true;
                if (!doOnce)
                {
                    interactedObj = hit.collider.gameObject.GetComponent<OBJInteract>();
                    CrosshairChange(true);
                }

                isCrossHairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactwithObj))
                {
                    StartCoroutine(Cooldown());
                    interactedObj.RotateTeleScope();
                }
            }
            ///////////////////////////////////////////////////////

            //// PILLAR ONE ////

            ///////////////////////////////////////////////////////
            if (hit.collider.CompareTag(pillarTag))
            {
                seeing = true;
                if (!doOnce)
                {
                    interactedObj = hit.collider.gameObject.GetComponent<OBJInteract>();
                    CrosshairChange(true);
                }

                isCrossHairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactwithObj))
                {
                    interactedObj.PillarMove();
                }
            }

            ///////////////////////////////////////////////////////

            //// PILLAR TWO ////

            ///////////////////////////////////////////////////////
            if (hit.collider.CompareTag(pillarTag2))
            {
                seeing = true;
                if (!doOnce)
                {
                    interactedObj = hit.collider.gameObject.GetComponent<OBJInteract>();
                    CrosshairChange(true);
                }

                isCrossHairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactwithObj))
                {
                    interactedObj.PillarMove2();
                }
            }

            ///////////////////////////////////////////////////////

            //// PILLAR THREE ////

            ///////////////////////////////////////////////////////
            if (hit.collider.CompareTag(pillarTag3))
            {
                seeing = true;
                if (!doOnce)
                {
                    interactedObj = hit.collider.gameObject.GetComponent<OBJInteract>();
                    CrosshairChange(true);
                }

                isCrossHairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactwithObj))
                {
                    interactedObj.PillarMove3();
                }
            }

            ///////////////////////////////////////////////////////

            //// PILLAR FOUR ////

            ///////////////////////////////////////////////////////
            if (hit.collider.CompareTag(pillarTag4))
            {
                seeing = true;
                if (!doOnce)
                {
                    interactedObj = hit.collider.gameObject.GetComponent<OBJInteract>();
                    CrosshairChange(true);
                }

                isCrossHairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactwithObj))
                {
                    interactedObj.PillarMove4();
                }
            }

            ///////////////////////////////////////////////////////

            //// PILLAR FIVE ////

            ///////////////////////////////////////////////////////
            if (hit.collider.CompareTag(pillarTag5))
            {
                seeing = true;
                if (!doOnce)
                {
                    interactedObj = hit.collider.gameObject.GetComponent<OBJInteract>();
                    CrosshairChange(true);
                }

                isCrossHairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactwithObj))
                {
                    interactedObj.PillarMove5();
                }
            }

            ///////////////////////////////////////////////////////

            //// PILLAR SIX ////

            ///////////////////////////////////////////////////////
            if (hit.collider.CompareTag(pillarTag6))
            {
                seeing = true;
                if (!doOnce)
                {
                    interactedObj = hit.collider.gameObject.GetComponent<OBJInteract>();
                    CrosshairChange(true);
                }

                isCrossHairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactwithObj))
                {
                    interactedObj.PillarMove6();
                }
            }
        }

        else
        {
            if(isCrossHairActive)
            {
                CrosshairChange(false);
                doOnce = false;
                seeing = false;
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

    IEnumerator Cooldown()
    {
        clickCooldown = true;
        yield return new WaitForSeconds(1);
        clickCooldown = false;
    }
}
