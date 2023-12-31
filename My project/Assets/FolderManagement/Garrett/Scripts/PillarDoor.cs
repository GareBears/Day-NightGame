using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarDoor : MonoBehaviour
{
    public bool secretBool = false;
    public bool secretBool2 = false;
    public bool secretBool3 = false;

    public bool fakeBool = false;
    public bool fakeBool2 = false;
    public bool fakeBool3 = false;

    private GameObject pillarDoor;

    private float openPosY;
    private float closedPosY;


    // Start is called before the first frame update
    void Start()
    {
        pillarDoor = GameObject.Find("PillarPuzzleDoor");
        openPosY = transform.position.y - 20f;
        closedPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fakeBool && !fakeBool2 && !fakeBool3)
        {
            if (secretBool)
            {
                if (secretBool2)
                {
                    if (secretBool3)
                    {
                        pillarDoor.transform.position = new Vector3(pillarDoor.transform.position.x, openPosY, pillarDoor.transform.position.z);
                    }
                }
            }
        }
        
        

        else if (!secretBool && secretBool2 && secretBool3 || !secretBool && !secretBool2 && secretBool3 || !secretBool && !secretBool2 && !secretBool3)
        {
            pillarDoor.transform.position = new Vector3(pillarDoor.transform.position.x, closedPosY, pillarDoor.transform.position.z);
        }

        else if (secretBool && !secretBool2 && secretBool3 || secretBool && !secretBool2 && !secretBool3)
        {
            pillarDoor.transform.position = new Vector3(pillarDoor.transform.position.x, closedPosY, pillarDoor.transform.position.z);
        }

        else if (secretBool && secretBool2 && !secretBool3 || !secretBool && secretBool2 && !secretBool3)
        {
            pillarDoor.transform.position = new Vector3(pillarDoor.transform.position.x, closedPosY, pillarDoor.transform.position.z);
        }

        else if (fakeBool || fakeBool2 || fakeBool3)
        {
            pillarDoor.transform.position = new Vector3(pillarDoor.transform.position.x, closedPosY, pillarDoor.transform.position.z);
        }
    }
}
