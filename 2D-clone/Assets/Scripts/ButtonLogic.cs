using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLogic : MonoBehaviour
{
    public LogicPause logicPause;
    public GameObject PauseMenu;
    public GameObject GameOver;
    public Sound sound;
    public bool restartScore;
    // Start is called before the first frame update
    void Start()
    {
        logicPause = FindObjectOfType<LogicPause>();
        restartScore = false;
        sound = FindObjectOfType<Sound>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        logicPause.pause = false;
        logicPause.gameOver = false;
        PauseMenu.SetActive(false);
        GameOver.SetActive(false);
        restartScore = true;
        //sound.PlayClick();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        logicPause.pause = false;
        PauseMenu.SetActive(false);
        //sound.PlayClick();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        logicPause.pause = false;
        logicPause.gameOver = false;
        PauseMenu.SetActive(false);
        GameOver.SetActive(false);
        restartScore = true;
        //sound.PlayClick();
    }
}
