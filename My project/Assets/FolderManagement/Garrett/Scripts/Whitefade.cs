using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Whitefade : MonoBehaviour
{
    private float startingPos;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position.y;
        transform.position = new Vector3(transform.position.x, startingPos + 2000, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            //transform.position = new Vector3(transform.position.x, startingPos, transform.position.z);
            WhitefadeTime();
        }
    }

    public void WhitefadeTime()
    {
        transform.position = new Vector3(transform.position.x, startingPos, transform.position.z);
        animator.SetTrigger("MainMenu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        //transform.position = new Vector3(transform.position.x, startingPos + 2000, transform.position.z);
    }
}
