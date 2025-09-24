using UnityEngine;

public enum MonsterState
{
    Idle,
    PlaterDetection,
    PlayerAttack
}

public class Monster : MonoBehaviour
{
    
    public GameObject player;
    private Rigidbody monsterRigid;

    public float speed = 2.0f;
    public float playerDetectRange = 50.0f;
    


    // ������ ���µ� �����ϱ�
    // ������, �÷��̾� �Ѵ� ����, �Ҹ��� �����Ͽ� �����̴� ����(N��), �÷��̾� ���� ����
    void Start()
    {
        monsterRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Vector3 distance = player.transform.position - this.transform.position;

        if (distance.sqrMagnitude <= playerDetectRange)
        {
            FollowPlayer();
        }
        else
        {
            //���� ������ ����
        }
    }

    private void FollowPlayer()
    {
        Vector3 moveInput = (player.transform.position - this.transform.position).normalized * speed;
        monsterRigid.MovePosition(monsterRigid.position + moveInput * Time.deltaTime);
    }
}
