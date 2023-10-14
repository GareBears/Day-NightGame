using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleporting : MonoBehaviour
{
    PlayerControls playerControls;

    public bool daytime = true;
    public bool nightime = false;

    public float playerPosN;
    public float playerPosD;

    public GameObject sunLight;
    public GameObject clock;
    public GameObject lantern;

    // Start is called before the first frame update
    void Start()
    {
        playerControls = gameObject.GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J) && daytime && playerControls.isGrounded == true)
        {
            StartCoroutine("BeginNight");
        }
        if (Input.GetKeyDown(KeyCode.J) && !daytime && playerControls.isGrounded == true)
        {
            StartCoroutine("BeginDay");
        }

        if (Input.GetKeyDown("1"))
        {
            clock.SetActive(true);
            lantern.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            clock.SetActive(false);
            lantern.SetActive(true);
        }

        playerPosN = transform.position.y + 200f;
        playerPosD = transform.position.y - 200f;



       
        
    }

    IEnumerator BeginNight()
    {
        playerControls.disabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = new Vector3(transform.position.x, playerPosN, transform.position.z);
        daytime = false;
        sunLight.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        playerControls.disabled = false;
    }

    IEnumerator BeginDay()
    {
        playerControls.disabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = new Vector3(transform.position.x, playerPosD, transform.position.z);
        daytime = true;
        sunLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        playerControls.disabled = false;
    }
}
