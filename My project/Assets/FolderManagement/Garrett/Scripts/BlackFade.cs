using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFade : MonoBehaviour
{
    public Animator animator;
    private bool fadecooldown = false;

    ScenManager scenManager;

    private int levelToLoad;

    private float startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position.y;
        //scenManager = GameObject.Find("SceneManager").GetComponent<ScenManager>();
    }

    private void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            FadeToLevel();
        }
    }

    public void FadeToLevel()
    {
        FadeToBlack(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToBlack(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
        //new WaitForSeconds(2);
        //SceneLoad();
        //StartCoroutine("ResetFade");
    }

    IEnumerator ResetFade()
    {
        yield return new WaitForSeconds(3);
        //animator.SetBool("FadeToBlack", false);
        //yield return new WaitForSeconds(1);
        //fadecooldown = false;
    }

    public void SceneLoad()
    {
        new WaitForSeconds(10);
        SceneManager.LoadScene(levelToLoad);
    }

    public void MoveFade()
    {
        transform.position = new Vector3(transform.position.x, startingPos + 2000, transform.position.z);
    }

    public void MoveFadeBack()
    {
        transform.position = new Vector3(transform.position.x, startingPos, transform.position.z);
    }
}
