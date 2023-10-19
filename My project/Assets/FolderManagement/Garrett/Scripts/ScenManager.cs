using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScenManager : MonoBehaviour
{
    public GameObject Title;
    public GameObject PlayButton;
    public GameObject Credits;
    public GameObject QuitButton;

    GameManager gameManager;
    BlackFade fadetoBlack;

    private int levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        fadetoBlack = GameObject.Find("LevelLoader").GetComponent<BlackFade>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        
    }

    public void LoadScene(int levelIndex)
    {
        fadetoBlack.FadeToLevel(); 
    }

    public void OnFadeComplete()
    {
        
    }

}
