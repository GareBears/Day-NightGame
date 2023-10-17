using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public bool disabled = false;

    public CharacterController characterController;
    Teleporting teleportScript;
    Interactable interactable;

    public float speed = 15f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    public bool freezing = false;
    public bool frozen;
    public bool overheating;
    public bool burning;
    public bool tempControl;

    public GameObject heatstroke;
    public GameObject heatburn;


    public void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
        teleportScript = GetComponent<Teleporting>();
        interactable = GameObject.Find("Interactable").GetComponent<Interactable>();
    }
    void Start()
    {
       
    }

    private void Update()
    {
        if(!disabled)
        {
            PlayerAwake();
        }

        if (tempControl)
        {
            // Overheating
            if (!overheating && !burning)
            {
                speed = 15f;
                heatstroke.SetActive(false);
            }
            else if (overheating && !burning)
            {
                speed = 7.5f;
                heatstroke.SetActive(true);
                heatburn.SetActive(false);
            }
            else if (overheating && burning)
            {
                speed = 1f;
                heatburn.SetActive(true);
            }
        }
        else if (!tempControl)
        {
            // Freezing
            if (!freezing && !frozen)
            {
                speed = 15;
            }
            else if (freezing && !frozen)
            {
                speed = 7.5f;
            }
            else if (freezing && frozen)
            {
                speed = 1f;
            }
        }
    }

    public void PlayerAwake()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            teleportScript.disabled = true;
        }
        if (other.tag == "Interactable")
        {
            interactable.OnPickUp();
        }
        if (other.tag == "Watch")
        {
            interactable.WatchPickUp();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            teleportScript.disabled = false;
        }
    }
}
