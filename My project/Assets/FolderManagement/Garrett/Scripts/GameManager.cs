using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerControls playerControls;
    Teleporting teleportScript;








    // Start is called before the first frame update
    void Awake()
    {
        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
        teleportScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Teleporting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

    }

    public void GameWin()
    {
        
    }
}
