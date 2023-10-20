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

    public float currentScene;
    private float mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position.y;
        //scenManager = GameObject.Find("SceneManager").GetComponent<ScenManager>();
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        mainMenu = currentScene - 1;

    }

    public void FadeToLevel()
    {
        if (currentScene == 1)
        {
            FadeToBlack(0);
        }
        if (currentScene == 0)
        {
            FadeToBlack(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void FadeToBlack(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    IEnumerator ResetFade()
    {
        yield return new WaitForSeconds(3);
    }

    public void SceneLoad()
    {
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
