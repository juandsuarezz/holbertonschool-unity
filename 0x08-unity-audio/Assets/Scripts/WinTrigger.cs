using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>Stops the timer when 'Player' reaches the flag</summary>
public class WinTrigger : MonoBehaviour
{
    public Text timerText;
    public GameObject winCanvas;
    public GameObject Timer;
    public AudioSource backgroundMusic;
    public AudioSource winMusic;

    void OnTriggerEnter(Collider change) 
    {
        if (change.name == "Player")
        {
            change.gameObject.GetComponent<Timer>().enabled = false;
            backgroundMusic.Stop();
            winMusic.Play();
            Timer.SetActive(false);
            winCanvas.SetActive(true);
        
            //timerText.fontSize = 75;
            //timerText.color = Color.green;
        }
    }
}
