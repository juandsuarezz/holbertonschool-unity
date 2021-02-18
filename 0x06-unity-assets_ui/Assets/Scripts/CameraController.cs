/*using UnityEngine;

///<summary>Handles camera control, allowing player to rotate the camera with the mouse</summary>
public class CameraController : MonoBehaviour
{
    public float turn = 3f;
    public Transform player;
    private Transform tsfrm;
    private Vector3 offset;
    private Quaternion turnX;
    private Quaternion turnY;

    public bool isInverted;
    private int inverted;

    void Awake()
    {
        tsfrm = GetComponent<Transform>();
    }

    void Start()
    {   
        Cursor.visible = false;
        offset = new Vector3(0, 1.25f, -6.25f);
        if (PlayerPrefs.GetString("IsInverted") != "")
            isInverted = bool.Parse(PlayerPrefs.GetString("IsInverted"));
        else
            isInverted = false;
    }

    void LateUpdate()
    {
        if (isInverted)
        {
            inverted = -1;
        }
        else
        {
            inverted = 1;
        }
        turnX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turn, Vector3.up);
        turnY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turn, Vector3.left);
        offset = turnX * turnY * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position + new Vector3(0, 0.24f, 0));
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform t;
    private Vector3 offset;
    private int inverted;

    public GameObject player;
    public float turnSpeed = 5.0f;

    public bool isInverted;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        offset = t.position - player.transform.position;
        if (PlayerPrefs.GetString("IsInverted") != "")
            isInverted = bool.Parse(PlayerPrefs.GetString("IsInverted"));
        else
            isInverted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInverted)
        {
            inverted = -1;
        }
        else
        {
            inverted = 1;
        }
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * inverted * turnSpeed, Vector3.left) * offset;
        t.position = player.transform.position + offset * Time.timeScale;
        transform.LookAt(player.transform.position);
    }
}
