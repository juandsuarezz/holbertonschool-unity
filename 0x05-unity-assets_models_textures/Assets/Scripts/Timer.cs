using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>Timer counts up as player traverses the level</summary>
public class Timer : MonoBehaviour
{
    public Text TimerText;
    private int min = 0;
    private float sec = 0.00f;
    private float time = 0f;
    private string text;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        min = (int)(time / 60);
        sec = (time % 60f);
        text = min.ToString() + ":" + sec.ToString("00.00");
        TimerText.text = text;
    }
}
