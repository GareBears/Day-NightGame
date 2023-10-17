using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMoving : MonoBehaviour
{
    private Animator pillarMoveAnim;
    public bool pillardown;
    public float pillarnumber;
    private bool secretBool;
    private bool secretBool2;
    private bool secretBool3;

    // Start is called before the first frame update
    void Start()
    {
        pillarMoveAnim = GameObject.Find("Pillar").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PillarMove()
    {

        Debug.Log("THIS IS A TEST");
        if (pillarnumber == 1)
        {
            if (!pillardown)
            {
                pillarMoveAnim.SetBool("PillarMove", true);
                secretBool = true;
            }
            else if (pillardown)
            {
                pillarMoveAnim.SetBool("PillarMove", false);
                secretBool = false;
            }
        }

    }
}
