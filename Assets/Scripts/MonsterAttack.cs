using System.Collections;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public float monsterAttackDamage = 20.0f;
    public float attackCoolTime = 1.0f;
    public PlayerHealth pHealth;

    private bool canAttack = true;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && canAttack)
        {
            pHealth.TakeDamage(monsterAttackDamage);
            canAttack = false;
            StartCoroutine(CoolTime());
        }
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(attackCoolTime);
        canAttack = true;
    }
}
