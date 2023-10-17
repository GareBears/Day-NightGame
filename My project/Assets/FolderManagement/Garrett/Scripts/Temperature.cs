using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    public float temperature;

    public bool inDay = true;

    PlayerControls playerControls;
    Teleporting teleporting;

    void Start()
    {
       playerControls = GetComponent<PlayerControls>();
        teleporting = GetComponent<Teleporting>();
    }

   
    void Update()
    {
        if (teleporting.hasWatch == true)
        {
            if (inDay && temperature <= 60f)
            {
                temperature += Time.deltaTime;
            }
            else if (!inDay && temperature >= -60f)
            {
                temperature -= Time.deltaTime;
            }

            if (temperature >= 0)
            {
                playerControls.tempControl = true;
            }
            else if (temperature <= 0)
            {
                playerControls.tempControl = false;
            }

            // Overheating
            if (temperature >= 40f)
            {
                playerControls.overheating = true;
            }
            else
            {
                playerControls.overheating = false;
            }

            // Burning
            if (temperature >= 50f)
            {
                playerControls.burning = true;
            }
            else
            {
                playerControls.burning = false;
            }

            // Freezing
            if (temperature <= -40f)
            {
                playerControls.freezing = true;
            }
            else
            {
                playerControls.freezing = false;
            }

            // Frozen
            if (temperature <= -55f)
            {
                playerControls.frozen = true;
            }
            else
            {
                playerControls.frozen = false;
            }
        }
        


    }

    private void FixedUpdate()
    {
        
    }
}
