using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleporting : MonoBehaviour
{

    public bool disabled;

    // Scripts ////////////////////////////////////////////////////////////////////
    PlayerControls playerControls; 
    SunRotate sunRotate;
    MoonRotate moonRotate;
    EquipWatch watchEquip;
    Temperature heat;

    // Time of Day  ///////////////////////////////////////////////////////////////
    public bool daytime = true;
    public bool nightime = false;
    public GameObject sunLight;
    
    // Positions //////////////////////////////////////////////////////////////////
    private float playerPosNX;
    private float playerPosDX;

    // Equipment //////////////////////////////////////////////////////////////////
    public float currentItem;
    public GameObject clock;
    public GameObject lantern;

    ///////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        currentItem = 1;
        playerControls = gameObject.GetComponent<PlayerControls>();
        heat = gameObject.GetComponent<Temperature>();
        
    }

    ///////////////////////////////////////////////////////////////////////////////
    void Update()
    {
        if (!disabled)
        {
            // DAY TRAVEL ( DO NOT TOUCH ) ////////////////////////////////////////
            if (currentItem == 2)
            {
                if (Input.GetKeyDown(KeyCode.J) && daytime && playerControls.isGrounded == true)
                {
                    StartCoroutine("BeginNight");
                    sunRotate.RotateDial();
                    moonRotate.RotateDial();
                }
                if (Input.GetKeyDown(KeyCode.J) && !daytime && playerControls.isGrounded == true)
                {
                    StartCoroutine("BeginDay");
                    sunRotate.ReturnDial();
                    moonRotate.ReturnDial();
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////

        // Equipment Select //////////////////////////////////////////////////////
        if (Input.GetKeyDown("1") && currentItem != 1)
        {
            currentItem = 1f;
            clock.SetActive(false);
            lantern.SetActive(false);
        }

        if (Input.GetKeyDown("2") && currentItem != 2)
        {
            clock.SetActive(true);
            sunRotate = GameObject.Find("SunDial").GetComponent<SunRotate>();
            moonRotate = GameObject.Find("MoonDial").GetComponent<MoonRotate>();
            watchEquip = GameObject.Find("Stopwatch").GetComponent<EquipWatch>();

            if (!daytime)
            {
                currentItem = 2f;
                //clock.SetActive(true);
                lantern.SetActive(false);
                watchEquip.EquipTheWatch();
                moonRotate.NightDial();
                sunRotate.NightDial();
            }
            else if (daytime)
            {
                currentItem = 2f;
                //clock.SetActive(true);
                lantern.SetActive(false);
                watchEquip.EquipTheWatch();
                moonRotate.DayDial();
                sunRotate.DayDial();
            }
        }
        if (Input.GetKeyDown("3") && currentItem != 3)
        {
            currentItem = 3f;
            clock.SetActive(false);
            lantern.SetActive(true);
        }
        /////////////////////////////////////////////////////////////////////////

        // Position Info ////////////////////////////////////////////////////////
        playerPosNX = transform.position.x + 300f;
        playerPosDX = transform.position.x - 300f;
    }

    ///////////////////////////////////////////////////////////////////////////////
    private void LateUpdate()
    {
        //sunRotate = GameObject.Find("SunDial").GetComponent<SunRotate>();
        //moonRotate = GameObject.Find("MoonDial").GetComponent<MoonRotate>();
        //watchEquip = GameObject.Find("Stopwatch").GetComponent<EquipWatch>();
    }

    ///////////////////////////////////////////////////////////////////////////////
    IEnumerator BeginNight()
    {
        playerControls.disabled = true;
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.position = new Vector3(playerPosNX, transform.position.y, transform.position.z);
        nightime = true;
        daytime = false;
        heat.inDay = false;
        sunLight.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        playerControls.disabled = false;
    }

    ///////////////////////////////////////////////////////////////////////////////
    IEnumerator BeginDay()
    {
        playerControls.disabled = true;
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.position = new Vector3(playerPosDX, transform.position.y, transform.position.z);
        daytime = true;
        nightime = false;
        heat.inDay = true;
        sunLight.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        playerControls.disabled = false;
    }
}
