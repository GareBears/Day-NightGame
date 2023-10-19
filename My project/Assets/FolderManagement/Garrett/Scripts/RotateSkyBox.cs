using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkyBox : MonoBehaviour
{
    public bool isrotating = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( isrotating == true)
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * -1f);
        }
    }
}
