using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    public AudioSource buttonRollover, buttonClick, cheery, victory, birds, footsteps, landing;
	public Slider sliderBGM, sliderSFX;
	public float sliderBGMvalue, sliderSFXvalue;

 	void Start() 
	{
		sliderBGM.value = PlayerPrefs.GetFloat("volumenBGM", 1f);
		sliderSFX.value = PlayerPrefs.GetFloat("volumenSFX", 1f);
        cheery.volume = sliderBGM.value;
		victory.volume = sliderBGM.value;
		birds.volume = sliderSFX.value;
		footsteps.volume = sliderSFX.value;
		landing.volume = sliderSFX.value;
		buttonClick.volume = sliderSFX.value;
		buttonRollover.volume = sliderSFX.value;
	}
    public void HoverAudio()
	{
		buttonRollover.Play();
	}
	public void ButtonClick()
	{
		buttonClick.Play();
	}

	public void ChangeSliderBGM(float valor)
    {
        sliderBGMvalue = valor;
        PlayerPrefs.SetFloat("volumenBGM", sliderBGMvalue);
        cheery.volume = sliderBGM.value;
		victory.volume = sliderBGM.value;
    }

	public void ChangeSliderSFX(float valor)
    {
        sliderSFXvalue = valor;
        PlayerPrefs.SetFloat("volumenSFX", sliderSFXvalue);
        birds.volume = sliderSFX.value;
		footsteps.volume = sliderSFX.value;
		landing.volume = sliderSFX.value;
		buttonClick.volume = sliderSFX.value;
		buttonRollover.volume = sliderSFX.value;
    }

}
