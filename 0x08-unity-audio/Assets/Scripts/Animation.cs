using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    int runStateHash = Animator.StringToHash("Base Layer.Running");
    //public float fallThreshold = -3f;
    //public float respawnThreshold = -20f;
    //public Transform spawnPoint;
    //public Transform startingPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //float move = Input.GetAxis("Vertical");
        //anim.SetFloat("Speed", move);
        
        //if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.D)||
            Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(jumpHash);
        }

        /*if (transform.position.y < fallThreshold)
        {
            //anim.SetTrigger("isFalling");
            anim.SetBool("Falling", true);
            anim.SetBool("Grounded", false);
        }

        if (transform.position.y < respawnThreshold)
        {
            //transform.position = new Vector3(0, 25, 0);
            //SpawnPlayer();
            //StartCoroutine(LoadScene(1f));
            transform.position = spawnPoint.position;
             
            anim.SetBool("Falling", false);
            Debug.Log("Falling no more");
            //anim.SetBool("Grounded", true);
        }*/

    }
}
