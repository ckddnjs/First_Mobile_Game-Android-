using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody playerRigid;
    private Transform playerCamera;

    public float speed = 10.0f;
    float preSpeed;
    public float mouseSensitivity = 150.0f;
    public float speedUpDurationTime = 5.0f;
    public float healthUpAmount = 10.0f;

    float xRotation = 0f;
    Vector3 moveInput;

    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        playerCamera = Camera.main.transform;

        // ȸ���� ������ ����x ����
        playerRigid.freezeRotation = true;

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

    private void OnTriggerEnter(Collider other)
    {
        ItemPickedUp item = other.GetComponent<ItemPickedUp>();
        if(item != null)
        {
            switch (item.itemData.itemType)
            {
                case ItemType.Potion:
                    HealthUp();
                    break;
                case ItemType.SpeedUp:
                    SpeedUp();
                        break;
                case ItemType.BrightSight:
                    // �ڵ� �����
                    break;
                case ItemType.Key:
                    // �ڵ� �����
                    break;
            }
            Destroy(other.gameObject); // 1ȸ�� ������, key�� ���ܷ� �ϴ��� ����@@
        }
    }

    private void SpeedUp()
    {
        preSpeed = speed;
        speed = 17; // ���� ���ǵ� 10
        StartCoroutine(SpeedDuration());
    }

    IEnumerator SpeedDuration()
    {
        yield return new WaitForSeconds(speedUpDurationTime); 
        speed = preSpeed;
    }

    private void HealthUp()
    {
        PlayerHealth pHealth = GetComponent<PlayerHealth>();
        if(pHealth != null)
        {
            if(pHealth.currentHealth == pHealth.maxHealth)
            {
                return;
            }
            else
            {
                pHealth.Heal(healthUpAmount);
            }
        }
    }
}
