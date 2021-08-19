using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    AudioSource  audioSource;
    public AudioClip pauseSound;
    public AudioClip rotateSound;
    public AudioClip deletelineSound;
    public AudioClip gameoverSound;
    public AudioClip holdSound;
    public AudioClip insertSound;
    public AudioClip moveSound;
    public AudioClip clickSound;
 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 1f);
        AudioListener.volume = slider.value;
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
    }

    public void PlayPause()
    {
        audioSource.PlayOneShot(pauseSound);
    }

    public void PlayRotate()
    {
        audioSource.PlayOneShot(rotateSound);
    }

    public void PlayClick()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void PlayDeleteline()
    {
        audioSource.PlayOneShot(deletelineSound);
    }

    public void PlayGameover()
    {
        audioSource.PlayOneShot(gameoverSound);
    }

    public void PlayHold()
    {
        audioSource.PlayOneShot(holdSound);
    }

    public void PlayInsert()
    {
        audioSource.PlayOneShot(insertSound);
    }

    public void PlayMove()
    {
        audioSource.PlayOneShot(moveSound);
    }
}
