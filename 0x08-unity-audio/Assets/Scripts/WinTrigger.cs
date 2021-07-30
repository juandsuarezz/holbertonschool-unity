using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public Timer timer;
    public PlayerController playerController;
    public GameObject flag, finalMenu;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        finalMenu.SetActive(false);
        flag.SetActive(true);
        timer = FindObjectOfType<Timer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController.playVictory();
            playerController.x = 0;
            playerController.y = 0;
            animator.SetBool("Suelo", true);
            playerController.canMove = false;
            finalMenu.SetActive(true);
            flag.SetActive(false);
            timer.finish = true;
        }
    }
}
