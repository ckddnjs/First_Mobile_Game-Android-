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
        // healthSlider에 값 입력
        healthSlider.value = currentHealth;

        Debug.Log("플레이어 데미지 : " + damage + ", 플레이어 현재 체력 : " + currentHealth);

        if(currentHealth <= 0)
        {
        // 짧은 시간에 여러번 공격 당해 -10, -20이 되면 코루틴 중복 가능 주의@
            isDead = true;
            StartCoroutine(Die());
        }
    }

    public bool Heal()
    {
        if (currentHealth == maxHealth)
        {
            Debug.Log("초과회복 우려, 사용안댐!");
            return false;
        }
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthSlider.value = currentHealth;

        Debug.Log("플레이어 체력 회복량 : " + healAmount + ", 플레이어 현재 체력 : " + currentHealth);
        return true;
    }

    IEnumerator Die()
    {
        Debug.Log("플레이어 사망");
        // 플레이어 균형 넘어지면서 쓰러지는 모습(gta 처럼, 2초 정도), 이후 씬 로드

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
