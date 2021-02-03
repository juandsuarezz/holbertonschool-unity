using UnityEngine;

///<summary>Handles camera control, allowing player to rotate the camera with the mouse</summary>
public class CameraController : MonoBehaviour
{
    public float turn = 3f;
    public Transform player;
    private Transform tsfrm;
    private Vector3 offset;
    private Quaternion turnX;
    private Quaternion turnY;

    void Awake()
    {
        tsfrm = GetComponent<Transform>();
    }

    void Start()
    {   
        Cursor.visible = false;
        offset = new Vector3(0, 1.25f, -6.25f);
    }

    void LateUpdate()
    {
        turnX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turn, Vector3.up);
        turnY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turn, Vector3.left);
        offset = turnX * turnY * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position + new Vector3(0, 0.24f, 0));
    }
}
