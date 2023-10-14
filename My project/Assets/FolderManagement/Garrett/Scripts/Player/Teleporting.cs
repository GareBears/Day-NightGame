using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleporting : MonoBehaviour
{
    PlayerControls playerControls;

    public bool daytime = true;
    public bool nightime = false;

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



       
        
    }

    IEnumerator BeginNight()
    {
        playerControls.disabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = new Vector3(transform.position.x, 201.58f, transform.position.z);
        daytime = false;
        yield return new WaitForSeconds(0.1f);
        playerControls.disabled = false;
    }

    IEnumerator BeginDay()
    {
        playerControls.disabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = new Vector3(transform.position.x, 1.58f, transform.position.z);
        daytime = true;
        yield return new WaitForSeconds(0.1f);
        playerControls.disabled = false;
    }
}
