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
    


    // 몬스터의 상태도 구별하기
    // 가만히, 플레이어 쫓는 상태, 소리에 반응하여 움직이는 상태(N초), 플레이어 공격 상태
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
            //몬스터 가만히 상태
        }
    }

    private void FollowPlayer()
    {
        Vector3 moveInput = (player.transform.position - this.transform.position).normalized * speed;
        monsterRigid.MovePosition(monsterRigid.position + moveInput * Time.deltaTime);
    }
}
