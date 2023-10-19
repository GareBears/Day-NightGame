using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleporting : MonoBehaviour
{

    public bool disabled;
    public bool hasWatch = false;
    public bool autoequip;

    public bool hasRuby;
    public bool hasEmerald;
    public bool hasSapphire;

    // Scripts ////////////////////////////////////////////////////////////////////
    PlayerControls playerControls; 
    SunRotate sunRotate;
    MoonRotate moonRotate;
    EquipWatch watchEquip;
    EquipLantern lanternEquip;
    Temperature heat;
    SleepFade whitefade;

    // Time of Day  ///////////////////////////////////////////////////////////////
    public bool daytime = true;
    public bool nightime = false;
    public GameObject sunLight;

    public Material daySkybox;
    public Material nightSkybox;
    
    // Positions //////////////////////////////////////////////////////////////////
    private float playerPosNX;
    private float playerPosDX;

    // Equipment //////////////////////////////////////////////////////////////////
    public float currentItem;
    public GameObject clock;
    public GameObject lantern;
    public GameObject note;
    public GameObject ToDo;

    ///////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        currentItem = 1;
        playerControls = gameObject.GetComponent<PlayerControls>();
        heat = gameObject.GetComponent<Temperature>();
        whitefade = GameObject.Find("Canvas").GetComponent<SleepFade>();
    }

    ///////////////////////////////////////////////////////////////////////////////
    void Update()
    {
        if (!disabled)
        {
            // DAY TRAVEL ( DO NOT TOUCH ) ////////////////////////////////////////
            if (currentItem == 2 && hasWatch)
            {
                if (Input.GetKeyDown(KeyCode.J) && daytime && playerControls.isGrounded == true && whitefade.fadecooldown == false)
                {
                    StartCoroutine("BeginNight");
                    sunRotate.RotateDial();
                    moonRotate.RotateDial();
                    whitefade.FadetoSleep();
                }
                if (Input.GetKeyDown(KeyCode.J) && !daytime && playerControls.isGrounded == true && whitefade.fadecooldown == false)
                {
                    StartCoroutine("BeginDay");
                    sunRotate.ReturnDial();
                    moonRotate.ReturnDial();
                    whitefade.FadetoSleep();
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
            note.SetActive(false);
            ToDo.SetActive(false);
        }

        if (Input.GetKeyDown("2") && currentItem != 2 && hasWatch)
        {
            //EquipWatch();
            clock.SetActive(true);
            sunRotate = GameObject.Find("SunDial").GetComponent<SunRotate>();
            moonRotate = GameObject.Find("MoonDial").GetComponent<MoonRotate>();
            watchEquip = GameObject.Find("Stopwatch").GetComponent<EquipWatch>();

            if (!daytime)
            {
                currentItem = 2f;
                //clock.SetActive(true);
                lantern.SetActive(false);
                note.SetActive(false);
                ToDo.SetActive(false);
                watchEquip.EquipTheWatch();
                moonRotate.NightDial();
                sunRotate.NightDial();
            }
            else if (daytime)
            {
                currentItem = 2f;
                //clock.SetActive(true);
                lantern.SetActive(false);
                note.SetActive(false);
                ToDo.SetActive(false);
                watchEquip.EquipTheWatch();
                moonRotate.DayDial();
                sunRotate.DayDial();
            }
        }
        if (Input.GetKeyDown("3") && currentItem != 3)
        {
            currentItem = 3f;
            clock.SetActive(false);
            note.SetActive(false);
            ToDo.SetActive(false);
            lantern.SetActive(true);
            lanternEquip = GameObject.Find("Playerlantern").GetComponent<EquipLantern>();
            lanternEquip.EquipTheLantern();
        }

        if (Input.GetKeyDown("4") && currentItem != 4)
        {
            note.SetActive(true);
            ToDo.SetActive(true);
            clock.SetActive(false);
            lantern.SetActive(false);
        }    
            /////////////////////////////////////////////////////////////////////////

            // Position Info ////////////////////////////////////////////////////////
            playerPosNX = transform.position.x + 1000f;
        playerPosDX = transform.position.x - 1000f;



        

    }

    ///////////////////////////////////////////////////////////////////////////////
    private void LateUpdate()
    {

    }

    ///////////////////////////////////////////////////////////////////////////////
    IEnumerator BeginNight()
    {
        playerControls.disabled = true;
        yield return new WaitForSeconds(1f);
        RenderSettings.skybox = nightSkybox;
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
        yield return new WaitForSeconds(1f);
        RenderSettings.skybox = daySkybox;
        gameObject.transform.position = new Vector3(playerPosDX, transform.position.y, transform.position.z);
        daytime = true;
        nightime = false;
        heat.inDay = true;
        sunLight.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        playerControls.disabled = false;
    }
}
