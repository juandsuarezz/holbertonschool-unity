using UnityEngine;
using System.Collections;

public class CharacterAnim : MonoBehaviour
{
    Animator anim;
    /// <summary> Player's Transform Component </summary>
    public Transform playerPos;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }

        /*if (playerPos.position.y >= -5)
        {
            anim.SetTrigger("isFalling");
        }*/
    }
    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Falling"))
        anim.SetBool("isFalling", true);
    }*/
}
