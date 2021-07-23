using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText, timerText2;
    public float actualTime = 0.0f;
    public bool finish;
    public GameObject timerCanvas;

    public string minutes, seconds;
    // Start is called before the first frame update
    void Start()
    {
        actualTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timerText2.text = timerText.text;
        if (!finish)
        {
            timerCanvas.SetActive(true);
            actualTime += Time.deltaTime;

            minutes = ((int) actualTime / 60).ToString();
            seconds = (actualTime % 60).ToString("00.00");

            timerText.text = minutes + ":" + seconds;
        }

        else
        {
            timerCanvas.SetActive(false);
            timerText.text = minutes + ":" + seconds;
            timerText.fontSize = 60;
        }
    }
}
