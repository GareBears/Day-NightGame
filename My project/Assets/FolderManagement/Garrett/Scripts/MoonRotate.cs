using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotate : MonoBehaviour
{
    public Animator moonRotate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateDial()
    {
        moonRotate.SetBool("MoonMove", true);
    }

    public void ReturnDial()
    {
        moonRotate.SetBool("MoonMove", false);
    }
}
