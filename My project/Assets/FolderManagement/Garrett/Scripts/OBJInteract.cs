using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using static Unity.VisualScripting.Member;
using UnityEngine.SceneManagement;

public class OBJInteract : MonoBehaviour
{
    PlayerControls playerControls;
    PillarDoor pillarDoor;
    ScenManager scenManager;
    BlackFade fadetoBlack;

    public GameObject blackfade;

    // Telescope //////////////////////////////////////////////
    public Animator telescopeAnim;
    public GameObject telescope;
    public float rotates = 0;
    public bool right;
    public bool wrong;

    public GameObject door;
    private float doorOpenPos;

    // Altar ////////////////////////////////////////////////
    private GameObject Altar;
    public GameObject Gems;
    public Animator altarAnim;

    // Pillars ////////////////////////////////////////////////
    public Animator pillarMoveAnim;
    public Animator pillarMoveAnim2;
    public Animator pillarMoveAnim3;
    public Animator pillarMoveAnim4;
    public Animator pillarMoveAnim5;
    public Animator pillarMoveAnim6;

    private bool pillardown = false;
    private bool pillardown2 = false;
    private bool pillardown3 = false;
    private bool pillardown4 = false;
    private bool pillardown5 = false;
    private bool pillardown6 = false;

    public bool secretBool = false;
    public bool secretBool2 = false;
    public bool secretBool3 = false;


    public GameObject pillar1;
    public GameObject pillarLantern1;

    public GameObject pillar2;
    public GameObject pillarLantern2;

    public GameObject pillar3;
    public GameObject pillarLantern3;

    public GameObject pillar4;
    public GameObject pillarLantern4;

    public GameObject pillar5;
    public GameObject pillarLantern5;

    public GameObject pillar6;
    public GameObject pillarLantern6;

    private void Awake()
    {
        
    }

    public void Start()
    {

        fadetoBlack = blackfade.GetComponent<BlackFade>();
        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
        scenManager = GameObject.Find("SceneManager").GetComponent<ScenManager>();

        ///////////////////////////////////////////////////////

        pillarDoor = GameObject.FindGameObjectWithTag("PillarPuzzleDoor").GetComponent<PillarDoor>();

        ///////////////////////////////////////////////////////

        doorOpenPos = door.transform.position.y;
        telescopeAnim = telescope.GetComponent<Animator>();

        ///////////////////////////////////////////////////////

        Altar = GameObject.FindGameObjectWithTag("Altar");
        altarAnim = Altar.GetComponent<Animator>();
        Gems = GameObject.Find("AltarPiece/Altar/AltarGems");

        ///////////////////////////////////////////////////////

        // Pillar 1 //
        pillarMoveAnim = GameObject.Find("PuzzlePillar1/FirePillar1").GetComponent<Animator>();
        pillar1 = GameObject.Find("PuzzlePillar1/FirePillar1");
        pillarLantern1 = GameObject.Find("PuzzlePillar1/FirePillar1/PillarLantern1");

        // Pillar 2 //
        pillarMoveAnim2 = GameObject.Find("PuzzlePillar2/FirePillar2").GetComponent<Animator>();
        pillar2 = GameObject.Find("PuzzlePillar2/FirePillar2");
        pillarLantern2 = GameObject.Find("PuzzlePillar2/FirePillar2/PillarLantern2");

        // Pillar 3 //
        pillarMoveAnim3 = GameObject.Find("PuzzlePillar3/FirePillar3").GetComponent<Animator>();
        pillar3 = GameObject.Find("PuzzlePillar3/FirePillar3");
        pillarLantern3 = GameObject.Find("PuzzlePillar3/FirePillar3/PillarLantern3");

        // Pillar 4 //
        pillarMoveAnim4 = GameObject.Find("PuzzlePillar4/FirePillar4").GetComponent<Animator>();
        pillar4 = GameObject.Find("PuzzlePillar4/FirePillar4");
        pillarLantern4 = GameObject.Find("PuzzlePillar4/FirePillar4/PillarLantern4");

        // Pillar 5 //
        pillarMoveAnim5 = GameObject.Find("FirePuzzle (DO NOT TOUCH)/PuzzlePillar5/FirePillar5").GetComponent<Animator>();
        pillar5 = GameObject.Find("FirePuzzle (DO NOT TOUCH)/PuzzlePillar5/FirePillar5");
        pillarLantern5 = GameObject.Find("FirePuzzle (DO NOT TOUCH)/PuzzlePillar5/FirePillar5/PillarLantern5");

        // Pillar 6 //
        pillarMoveAnim6 = GameObject.Find("PuzzlePillar6/FirePillar6").GetComponent<Animator>();
        pillar6 = GameObject.Find("PuzzlePillar6/FirePillar6");
        pillarLantern6 = GameObject.Find("PuzzlePillar6/FirePillar6/PillarLantern6");
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
    
    public void AltarInteract()
    {
        if (playerControls.canWin == true)
        {
            Gems.SetActive(true);
            Debug.Log("Hello");
            altarAnim.SetBool("AltarDown", true);
            playerControls.disabled = true;
            //scenManager.LoadScene(1);
            fadetoBlack.FadeToLevel();
            //SceneManager.LoadScene(0);
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
            pillarDoor.fakeBool = true;
            pillardown2 = true;
            pillarLantern2.SetActive(true);
        }
        else if (pillardown2)
        {
            pillarMoveAnim2.SetBool("PillarMove2", false);
            pillarDoor.fakeBool = false;
            pillardown2 = false;
            pillarLantern2.SetActive(false);
        }
    }

    public void PillarMove3()
    {
        if (!pillardown3)
        {
            pillarMoveAnim3.SetBool("PillarMove3", true);
            pillarDoor.fakeBool2 = true;
            pillardown3 = true;
            pillarLantern3.SetActive(true);
        }
        else if (pillardown3)
        {
            pillarMoveAnim3.SetBool("PillarMove3", false);
            pillarDoor.fakeBool2 = false;
            pillardown3 = false;
            pillarLantern3.SetActive(false);
        }
    }

    public void PillarMove4()
    {
        if (!pillardown4)
        {
            pillarMoveAnim4.SetBool("PillarMove4", true);
            pillarDoor.secretBool2 = true;
            pillardown4 = true;
            pillarLantern4.SetActive(true);

        }
        else if (pillardown4)
        {
            pillarMoveAnim4.SetBool("PillarMove4", false);
            pillarDoor.secretBool2 = false;
            pillardown4 = false;
            pillarLantern4.SetActive(false);
            
        }
    }

    public void PillarMove5()
    {
        if (!pillardown5)
        {
            pillarMoveAnim5.SetBool("PillarMove5", true);
            pillarDoor.secretBool3 = true;
            pillardown5 = true;
            pillarLantern5.SetActive(true);
        }
        else if (pillardown5)
        {
            pillarMoveAnim5.SetBool("PillarMove5", false);
            pillarDoor.secretBool3 = false;
            pillardown5 = false;
            pillarLantern5.SetActive(false);
        }
    }

    public void PillarMove6()
    {
        if (!pillardown6)
        {
            pillarMoveAnim6.SetBool("PillarMove6", true);
            pillarDoor.fakeBool3 = true;
            pillardown6 = true;
            pillarLantern6.SetActive(true);
        }
        else if (pillardown6)
        {
            pillarMoveAnim6.SetBool("PillarMove6", false);
            pillarDoor.fakeBool3 = false;
            pillardown6 = false;
            pillarLantern6.SetActive(false);
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

        if (rotates == 4)
        {
            rotates = 0;
        }

        if (right == true && wrong == false)
        {
            door.transform.position = new Vector3(door.transform.position.x, doorOpenPos - 6f, door.transform.position.z);
        }
        else if (right == false && wrong == true)
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
