using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public Rigidbody pRigid;
    public Player pMove;

    public bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        pRigid = GetComponent<Rigidbody>();
        pMove = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(100f);
        }
    }

    public void TakeDamage(float damage)
    {

        if(isDead)
        {
            return;
        }

        currentHealth -= damage;

        Debug.Log("�÷��̾� ���� ü�� : " + currentHealth);

        if(currentHealth <= 0)
        {
        // ª�� �ð��� ������ ���� ���� -10, -20�� �Ǹ� �ڷ�ƾ �ߺ� ���� ����@
            isDead = true;
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        Debug.Log("�÷��̾� ���");
        // �÷��̾� ���� �Ѿ����鼭 �������� ���(gta ó��, 2�� ����), ���� �� �ε�

        if(pMove != null)
        {
            pMove.enabled = false;
        }

        if(pRigid != null)
        {
            pRigid.constraints = RigidbodyConstraints.None;
            pRigid.AddTorque(transform.right * 10f);
        }

        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene("GameOverScene");
    }
}
