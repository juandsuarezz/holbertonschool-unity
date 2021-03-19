using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private bool isCoroutine = true;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Animator anim;
    public Transform playerTransform;
    public Transform spawnPoint;
    public Transform startingPoint;
    public float fallThreshold = -3f;
    public float respawnThreshold = -20f;
    public AudioSource footsteps;
    public AudioSource impact;

    bool grounded = false;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerTransform = GameObject.Find("Player").transform;
        //anim = GetComponent<Animator>();
        InvokeRepeating ("PlaySound", 0.0f, 0.5f);
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                anim.SetTrigger("Jump");
                moveDirection.y = jumpSpeed;
            }
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }

            if (moveDirection.magnitude >= 0.01f)
            {
                //anim.SetBool("isRunning", true);
                
                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
                characterController.Move(moveDirection * speed * Time.deltaTime);
            }
            else
                anim.SetBool("isRunning", false);
                footsteps.Stop();
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
    void FixedUpdate ()
    {
        if (transform.position.y < fallThreshold)
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
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Falling"))
          //  {
            //    anim.SetTrigger("isFalling");
              //  Debug.Log("Falling");
            //}
        if (other.CompareTag("Flat"))
        {
            transform.position = playerTransform.position;

            anim.SetBool("Grounded", true);
            anim.SetTrigger("getUp");
            //grounded = true;
            impact.Play();
            Debug.Log("SPLAT!!!");

            if (grounded == true)
            {
                anim.SetBool("backToIdle", true);
                anim.SetBool("Grounded", false);
                
                Debug.Log("BackToIdle");
                //transform.position = new Vector3 (0, -1, 0);   
            }
        }
        if (other.CompareTag("Transform"))
        {
            transform.position = startingPoint.position;
            Debug.Log("Transform");
        }
        
            //anim.SetBool("Grounded", false);
            //anim.SetBool("backToIdle", true);
            //transform.position = new Vector3 (0, -1, 0);
            //transform.position = startingPoint.position;
        

        
        //if (other.CompareTag("Respawn"))
            //SpawnPlayer();
            //StartCoroutine(LoadScene(1f));
            //SpawnPlayer();
            

            //StartCoroutine(LoadScene(1f));
            //anim.SetTrigger("fallingFlat");
    }
    
    

     /*private void OnCollisionEnter(Collision other)
    {
        anim.SetBool("Falling", false);
        anim.SetBool("Grounded", true);
    }*/

    void SpawnPlayer()
    {
        transform.position = new Vector3 (0, 25, 0);
        Debug.Log(transform.position);
        //anim.SetTrigger("fallingFlat");
    }

    IEnumerator LoadScene(float seconds)
    {
        isCoroutine = false;
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Level01");
        isCoroutine = true;
    }
    void PlaySound ()
    {
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            footsteps.Play();
            //anim.SetBool("isRunning", true);
        }
        else
        {
            footsteps.Stop();
            //anim.SetBool("isRunning", false);
        }
     }
    
}

