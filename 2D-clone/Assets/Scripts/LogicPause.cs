using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicPause : MonoBehaviour
{
    public bool pause;
    public bool gameOver;
    public GameObject PauseMenu;
    public GameObject GameOver;
    public Sound sound;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        pause = false;
        PauseMenu.SetActive(false);
        GameOver.SetActive(false);
        sound = FindObjectOfType<Sound>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !gameOver)
        {
            PausarJuego();
        }
    }

    public void PausarJuego()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pause = true;
            PauseMenu.SetActive(true);
            sound.PlayPause();
        }
        else
        {
            Time.timeScale = 1;
            pause = false;
            PauseMenu.SetActive(false);
        }
    }

    public void SetGameOver()
    {
        sound.PlayGameover();
        Time.timeScale = 0;
        pause = true;
        gameOver = true;
        GameOver.SetActive(true);
    }
}
