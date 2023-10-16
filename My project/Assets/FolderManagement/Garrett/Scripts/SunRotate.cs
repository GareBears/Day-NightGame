using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotate : MonoBehaviour
{
    public Animator sunRotate;

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
        sunRotate.SetBool("SunMoves", true);
    }

    public void ReturnDial()
    {
        sunRotate.SetBool("SunMoves", false);
    }

    public void DayDial()
    {
        sunRotate.SetBool("NightTime", false);
        sunRotate.SetBool("SunMoves", false);
    }

    public void NightDial()
    {
        sunRotate.SetBool("NightTime", true);
        sunRotate.SetBool("SunMoves", true);
    }
}
