using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle inverted;
    int backScene;
    public GameObject pauseCanvas;


    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
        pauseCanvas.SetActive(true);
    }

    public void Apply()
    {
        PlayerPrefs.SetString("IsInverted", inverted.isOn.ToString());
        Back();
    }
    public void SetScene(int prevScene)
	{
		backScene = prevScene;
	}
}