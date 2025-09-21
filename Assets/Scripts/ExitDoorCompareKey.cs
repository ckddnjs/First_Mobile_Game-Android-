using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorCompareKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (other.CompareTag("Player"))
        {
            if(player != null && player.HasKey) {
                SceneManager.LoadScene("GameOverScene");
            }
            else
            {
                Debug.Log("Ű�� �ʿ��մϴ�. Ű�� ã�ƿ�����!");
            }
        }
        else // ���� ���Ͱ� �����̴ٰ� ���� ���� �����ϱ�
        {
            return;
        }
    }
}
