using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{
    public Text scoreText;
    public int scoreValue;
    public static int highScore;
    public Text highScoreText;
    public Text scorePause;
    public Text gameOverText;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("newhighscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        SetScoreText();
        SetPauseText();
        SetGameOverText();
        PlayerPrefs.SetInt("newhighscore", highScore);
    }

    void SetScoreText()
    {
        scoreText.text = scoreValue.ToString();
        if(highScore <= scoreValue)
        {
            highScore = scoreValue;
        }
        highScoreText.text = highScore.ToString();
    }

    void SetPauseText()
    {
        scorePause.text = "SCORE: " + scoreValue.ToString();
    }

    void SetGameOverText()
    {
        gameOverText.text = "FINAL SCORE: " + scoreValue.ToString();
    }

    public void MuteMusic()
    {
        audioSource.mute = true;
    }

    public void UnmuteMusic()
    {
        audioSource.mute = false;
    }
}
