using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class OBJInteract : MonoBehaviour
{
    PillarDoor pillarDoor;

    // Telescope //////////////////////////////////////////////
    private Animator telescopeAnim;
    public float rotates = 0;
    public bool right;
    public bool wrong;

    public GameObject door;
    private float doorOpenPos;

    // Pillars ////////////////////////////////////////////////
    private Animator pillarMoveAnim;
    private Animator pillarMoveAnim2;
    private Animator pillarMoveAnim3;
    private Animator pillarMoveAnim4;
    private Animator pillarMoveAnim5;
    private Animator pillarMoveAnim6;

    private bool pillardown = false;
    private bool pillardown2 = false;
    private bool pillardown3 = false;
    private bool pillardown4 = false;
    private bool pillardown5 = false;
    private bool pillardown6 = false;

    public bool secretBool = false;
    public bool secretBool2 = false;
    public bool secretBool3 = false;


    private GameObject pillar1;
    private GameObject pillarLantern1;

    private GameObject pillar2;
    private GameObject pillarLantern2;

    private GameObject pillar3;
    private GameObject pillarLantern3;

    private GameObject pillar4;
    private GameObject pillarLantern4;

    private GameObject pillar5;
    private GameObject pillarLantern5;

    private GameObject pillar6;
    private GameObject pillarLantern6;

    private void Awake()
    {
        pillarDoor = GameObject.FindGameObjectWithTag("PillarPuzzleDoor").GetComponent<PillarDoor>();

        ///////////////////////////////////////////////////////

        doorOpenPos = door.transform.position.y;
        telescopeAnim = GameObject.Find("Telescope").GetComponent<Animator>();

        ///////////////////////////////////////////////////////

        // Pillar 1 //
        pillarMoveAnim = GameObject.Find("PuzzlePillar1/FirePillar1").GetComponent<Animator>();
        pillarLantern1 = GameObject.Find("PuzzlePillar1/FirePillar1/PillarLantern1");
        pillar1 = GameObject.Find("PuzzlePillar1/FirePillar1");

        // Pillar 2 //
        pillarMoveAnim2 = GameObject.Find("PuzzlePillar2/FirePillar2").GetComponent<Animator>();
        pillar2 = GameObject.Find("PuzzlePillar2/FirePillar2");

        // Pillar 3 //
        pillarMoveAnim3 = GameObject.Find("PuzzlePillar3/FirePillar3").GetComponent<Animator>();
        pillar3 = GameObject.Find("PuzzlePillar3/FirePillar3");

        // Pillar 4 //
        pillarMoveAnim4 = GameObject.Find("PuzzlePillar4/FirePillar4").GetComponent<Animator>();
        pillar4 = GameObject.Find("PuzzlePillar4/FirePillar4");

        // Pillar 5 //
        pillarMoveAnim5 = GameObject.Find("PuzzlePillar5/FirePillar5").GetComponent<Animator>();
        pillar5 = GameObject.Find("PuzzlePillar5/FirePillar5");

        // Pillar 6 //
        pillarMoveAnim6 = GameObject.Find("PuzzlePillar6/FirePillar6").GetComponent<Animator>();
        pillar6 = GameObject.Find("PuzzlePillar6/FirePillar6");
    }

    public void RotateTeleScope()
    {
        if (rotates == 0)
        { 
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

    ///////////////////////////////////////////////////////

    public void PillarMove()
    {
        if (!pillardown)
        {
            pillarMoveAnim.SetBool("PillarMove", true);
            pillarDoor.secretBool = true;
            pillardown = true;
            pillarLantern1.SetActive(true);
        }
        else if (pillardown)
        {
            pillarMoveAnim.SetBool("PillarMove", false);
            pillarDoor.secretBool = false;
            pillardown = false;
            pillarLantern1.SetActive(false);
        }
    }

    public void PillarMove2()
    {
        if (!pillardown2)
        {
            pillarMoveAnim2.SetBool("PillarMove2", true);
            pillardown2 = true;
            //pillarLantern2.SetActive(true);
        }
        else if (pillardown2)
        {
            pillarMoveAnim2.SetBool("PillarMove2", false);
            pillardown2 = false;
            //pillarLantern2.SetActive(false);
        }
    }

    public void PillarMove3()
    {
        if (!pillardown3)
        {
            pillarMoveAnim3.SetBool("PillarMove3", true);
            pillardown3 = true;
            //pillarLantern3.SetActive(true);
        }
        else if (pillardown3)
        {
            pillarMoveAnim3.SetBool("PillarMove3", false);
            pillardown3 = false;
            //pillarLantern3.SetActive(false);
        }
    }

    public void PillarMove4()
    {
        if (!pillardown4)
        {
            pillarMoveAnim4.SetBool("PillarMove4", true);
            pillarDoor.secretBool2 = true;
            pillardown4 = true;
            //pillarLantern4.SetActive(true);

        }
        else if (pillardown4)
        {
            pillarMoveAnim4.SetBool("PillarMove4", false);
            pillarDoor.secretBool2 = false;
            pillardown4 = false;
            //pillarLantern3.SetActive(false);
            
        }
    }

    public void PillarMove5()
    {
        if (!pillardown5)
        {
            pillarMoveAnim5.SetBool("PillarMove5", true);
            pillarDoor.secretBool3 = true;
            pillardown5 = true;
            //pillarLantern5.SetActive(true);
        }
        else if (pillardown5)
        {
            pillarMoveAnim5.SetBool("PillarMove5", false);
            pillarDoor.secretBool3 = false;
            pillardown5 = false;
            //pillarLantern5.SetActive(false);
        }
    }

    public void PillarMove6()
    {
        if (!pillardown6)
        {
            pillarMoveAnim6.SetBool("PillarMove6", true);
            pillardown6 = true;
            //pillarLantern6.SetActive(true);
        }
        else if (pillardown6)
        {
            pillarMoveAnim6.SetBool("PillarMove6", false);
            pillardown6 = false;
            //pillarLantern6.SetActive(false);
        }
    }

    ///////////////////////////////////////////////////////

    IEnumerator ResetBools()
    {
        yield return new WaitForSeconds(1);
        rotates = rotates + 1;
        telescopeAnim.SetBool("TeleRotate", false);
    }

    ///////////////////////////////////////////////////////

    private void Update()
    {
        ///////////////////////////////////////////////////////

        //// TELESCOPE STUFF ////

        ///////////////////////////////////////////////////////

        if (rotates >= 4)
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

    public void ActivateSecret(int  secret)
    {
        if (secret == 1)
        {
            secretBool = true;
        }
        if (secret == 2)
        {

        }
        if (secret == 3)
        {

        }
        if (secret == 4)
        {
            secretBool2 = true;
        }
        if (secret == 5)
        {
            secretBool3 = true;
        }
        if (secret == 6)
        {

        }
    }
}
