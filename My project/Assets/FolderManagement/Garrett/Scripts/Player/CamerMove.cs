using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMove : MonoBehaviour
{
    public Transform cameraPosition;

    void Start()
    {
        
    }

    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
