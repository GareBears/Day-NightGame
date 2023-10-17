using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class OBJInteract : MonoBehaviour
{
    //private Animator objAnim;


    // Telescope //////////////////////////////////////////////
    private Animator telescopeAnim;
    public float rotates = 0;
    public bool right;
    public bool wrong;

    public GameObject door;
    private float doorOpenPos;

    // Pillars ////////////////////////////////////////////////
    //private Animator pillarMoveAnim;
    //public bool pillardown;
    //public float pillarnumber;
    //private bool secretBool;
    //private bool secretBool2;
    //private bool secretBool3;


    private bool objRotated = false;

    private void Awake()
    {
        //objAnim = gameObject.GetComponent<Animator>();


        doorOpenPos = door.transform.position.y;


        telescopeAnim = GameObject.Find("Telescope").GetComponent<Animator>();
        //pillarMoveAnim = GameObject.Find("Pillar").GetComponent<Animator>();
    }

    public void RotateOBJ()
    {
        //if (!objRotated)
        //{
            //objAnim.Play("ObjRotate", 0, 0.0f);
            //objRotated = true;
        //}
        //else
        //{
            //objAnim.Play("ObjUnRotate", 0, 0.0f);
            //objRotated = false;
        //}
    }

    public void RotateTeleScope()
    {
        if (rotates == 0)
        {
            //telescopeAnim.Play("TeleRotate");
            
            telescopeAnim.SetBool("TeleRotate", true);
            StartCoroutine(ResetBools());
            wrong = true;
            right = false;
        }
        if (rotates == 1)
        {
            
            telescopeAnim.SetBool("TeleRotate", true);
            StartCoroutine(ResetBools());
            wrong = true;
            right = false;
        }
        if (rotates == 2)
        {
            telescopeAnim.SetBool("TeleRotate", true);
            StartCoroutine(ResetBools());
            wrong = false;
            right = true;
        }
        if (rotates == 3)
        {
            telescopeAnim.SetBool("TeleRotate", true);
            StartCoroutine(ResetBools());
            wrong = true;
            right = false;
        }

        

    }

    public void PillarMove()
    {

        //Debug.Log("THIS IS A TEST");
        //if (pillarnumber == 1)
        //{
            //if (!pillardown)
            //{
           //     pillarMoveAnim.SetBool("PillarMove", true);
            //    secretBool = true;
           // }
         //   else if (pillardown)
         //   {
          //      pillarMoveAnim.SetBool("PillarMove", false);
         //       secretBool = false;
          //  }
      //  }

    }



    IEnumerator ResetBools()
    {
        yield return new WaitForSeconds(1);
        rotates = rotates + 1;
        telescopeAnim.SetBool("TeleRotate", false);
    }

    private void Update()
    {
        if(rotates >= 4)
        {
            rotates = 0;
        }

        if (right == true && wrong == false)
        {
            door.transform.position = new Vector3(door.transform.position.x, doorOpenPos - 6f, door.transform.position.z);
        }
        if (right == false && wrong == true)
        {
            door.transform.position = new Vector3(door.transform.position.x, doorOpenPos, door.transform.position.z);
        }

    }
}
