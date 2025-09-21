using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float healAmount = 10f;

    public Rigidbody pRigid;
    public Player pMove;
    public Slider healthSlider;

    public bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        pRigid = GetComponent<Rigidbody>();
        pMove = GetComponent<Player>();
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
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
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
        // healthSlider�� �� �Է�
        healthSlider.value = currentHealth;

        Debug.Log("�÷��̾� ������ : " + damage + ", �÷��̾� ���� ü�� : " + currentHealth);

        if(currentHealth <= 0)
        {
        // ª�� �ð��� ������ ���� ���� -10, -20�� �Ǹ� �ڷ�ƾ �ߺ� ���� ����@
            isDead = true;
            StartCoroutine(Die());
        }
    }

    public bool Heal()
    {
        if (currentHealth == maxHealth)
        {
            Debug.Log("�ʰ�ȸ�� ���, ���ȴ�!");
            return false;
        }
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthSlider.value = currentHealth;

        Debug.Log("�÷��̾� ü�� ȸ���� : " + healAmount + ", �÷��̾� ���� ü�� : " + currentHealth);
        return true;
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
