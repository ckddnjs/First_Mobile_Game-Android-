using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody playerRigid;
    private Transform playerCamera;

    public float speed = 10.0f;
    public float mouseSensitivity = 150.0f;

    float xRotation = 0f;
    Vector3 moveInput;

    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        playerCamera = Camera.main.transform;

        // ȸ���� ������ ����x ����
        playerRigid.freezeRotation = true;

        // ���콺 �߾� ����
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveInput = (transform.right * x + transform.forward * z).normalized * speed;

        SightMove();
    }
    void FixedUpdate()
    {
        playerRigid.MovePosition(playerRigid.position + moveInput * Time.deltaTime);    
    }

    private void SightMove()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // �÷��̰Ű� ���콺�� ���� ���� �����
        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
