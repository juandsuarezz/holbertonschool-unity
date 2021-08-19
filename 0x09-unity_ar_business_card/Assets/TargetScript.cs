using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/juandsuarezw");
    }

    public void OpenLinkedin()
    {
        Application.OpenURL("https://www.linkedin.com/in/juandavidsuarez/");
    }

    public void OpenGithub()
    {
        Application.OpenURL("https://github.com/juandsuarezz");
    }

    public void OpenYoutube()
    {
        Application.OpenURL("mailto:jdsw619@gmail.com");
    }
}
