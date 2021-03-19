using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle inverted;
    int backScene;
    public GameObject pauseCanvas;
    public AudioSource buttonRollover;
	public AudioSource buttonClick;
    public AudioMixer mixer;

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
        pauseCanvas.SetActive(true);
    }

    public void Apply()
    {
        PlayerPrefs.SetString("IsInverted", inverted.isOn.ToString());
        PlayerPrefs.SetFloat("BGMVol", GameObject.Find("BGMSlider").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("SFXVol", GameObject.Find("SFXSlider").GetComponent<Slider>().value);
        this.mixer.SetFloat("BGMVol", PlayerPrefs.GetFloat("BGMVol") != 0 ? 20 * Mathf.Log10(PlayerPrefs.GetFloat("BGMVol")) : -144);
        this.mixer.SetFloat("RunningVol", PlayerPrefs.GetFloat("SFXVol") != 0 ? 20 * Mathf.Log10(PlayerPrefs.GetFloat("SFXVol")) : -144);
        this.mixer.SetFloat("LandingVol", PlayerPrefs.GetFloat("SFXVol") != 0 ? 20 * Mathf.Log10(PlayerPrefs.GetFloat("SFXVol")) : -144);
        this.mixer.SetFloat("AmbientVol", PlayerPrefs.GetFloat("SFXVol") != 0 ? 20 * Mathf.Log10(PlayerPrefs.GetFloat("SFXVol")) : -144);
        //Back();
    }
    public void SetScene(int prevScene)
	{
		backScene = prevScene;
	}
    public void HoverAudio()
	{
		buttonRollover.Play();
	}
	public void ButtonClick()
	{
		buttonClick.Play();
	}
    private void Start() {
        if (PlayerPrefs.HasKey("InvertY"))
            this.GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt("InvertY") == 0 ? false : true;
        else
            this.GetComponentInChildren<Toggle>().isOn = false;

        if (PlayerPrefs.HasKey("BGMVol"))
            GameObject.Find("BGMSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("BGMVol");
        else
            GameObject.Find("BGMSlider").GetComponent<Slider>().value = 1;
            
        if (PlayerPrefs.HasKey("SFXVol"))
            GameObject.Find("SFXSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXVol");
        else
            GameObject.Find("SFXSlider").GetComponent<Slider>().value = 1;
    }
}