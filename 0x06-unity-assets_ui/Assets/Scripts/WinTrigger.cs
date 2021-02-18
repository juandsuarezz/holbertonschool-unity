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

    void OnTriggerEnter(Collider change) 
    {
        if (change.name == "Player")
        {
            change.gameObject.GetComponent<Timer>().enabled = false;
            Timer.SetActive(false);
            winCanvas.SetActive(true);
        
            //timerText.fontSize = 75;
            //timerText.color = Color.green;
        }
    }
}
