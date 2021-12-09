using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject menucanvas, optionscanvas, feidOut, fadeIn;  
    public string sceneString;
    // Start is called before the first frame update
    void Start()
    {
        fadeIn.SetActive(true);
        StartCoroutine("FalseFeid");
        feidOut.SetActive(false);
        menucanvas.SetActive(true);
        optionscanvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.5f);
    }

    public void OptionsButton()
    {
        menucanvas.SetActive(false);
        optionscanvas.SetActive(true);
    }

    public void BackButton()
    {
        menucanvas.SetActive(true);
        optionscanvas.SetActive(false);
    }

    public void LevelButtons(string stringScene)
    {
        sceneString = stringScene;
        StartCoroutine("ChangeScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    IEnumerator ChangeScene()
    {
        feidOut.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(sceneString);
    }

    IEnumerator FalseFeid()
    {
        yield return new WaitForSeconds(1.4f);
        fadeIn.SetActive(false);
    }
}
