using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velMov = 5.0f;
    public float velRot = 300.0f;
    public Rigidbody rb;
    public float jumpForce = 5.4f;
    public bool canJump;
    public bool canMove;
    public float x, y;
    public Animator animator;
    public GameObject pauseMenu, optionsMenu, feid, fadeOut, cam1, cam2;
    public Timer timer;
    public string SceneText;

    // Start is called before the first frame update
    void Start()
    {
        timer.finish = true;
        cam1.SetActive(false);
        cam2.SetActive(true);
        fadeOut.SetActive(false);
        feid.SetActive(true);
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        SetPosition();
        canMove = false;
        canJump = false;
        StartCoroutine("intro");
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            if (transform.position.y <= -5f)
            {
                SetPosition();
            }
            animator.SetFloat("Blend", y);
        }        
    }

    private void FixedUpdate() 
    {   
        if(canMove)
        {
            transform.Translate(0, 0, y * Time.deltaTime * velMov);
            transform.Rotate(0, x * Time.deltaTime * velRot, 0);

            if(Input.GetKeyDown(KeyCode.P))
            {
                pauseMenu.SetActive(true);
                canMove = false;
                Time.timeScale = 0;
            }
        }
        if(canMove && canJump)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Salto", true);
                rb.AddForce(new Vector3(0, jumpForce, 0),ForceMode.Impulse);
                canJump = false;
            }
            animator.SetBool("Suelo", true);
        }
        else
        {
            animator.SetBool("Suelo", false);
            animator.SetBool("Salto", false);
        }

        if(!canMove)
        {
            animator.SetBool("Suelo", true);
            animator.SetBool("Salto", false);
            x = 0;
            y = 0;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        canJump = true;
    }

    private void OnCollisionExit(Collision other)
    {
        canJump = false;
    }

    public void SetPosition()
    {
        transform.position = new Vector3 (0f, 12f, 0f);
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);
    }

    public void OptionsButton()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void BackButton()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void RestartButton()
    {
        pauseMenu.SetActive(false);
        canMove = true;
        Time.timeScale = 1;
        SetPosition();
        timer.actualTime = 0.0f;
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        canMove = true;
        Time.timeScale = 1;
    }
    public void MenuBotton()
    {
        Time.timeScale = 1;
        SceneText = "MainMenu";
        StartCoroutine("ChangeScene");
    }

    public void NextButton(string TextScene)
    {
        SceneText = TextScene;
        StartCoroutine("ChangeScene");
    }
    IEnumerator ChangeScene()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(SceneText);
    }
    IEnumerator intro()
    {
        yield return new WaitForSeconds(3.3f);
        cam1.SetActive(true);
        cam2.SetActive(false);
        timer.finish = false;
        canMove = true;
    }
}
