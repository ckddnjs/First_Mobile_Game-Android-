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
                Debug.Log("키가 필요합니다. 키를 찾아오세요!");
            }
        }
        else // 만약 몬스터가 움직이다가 만날 수도 있으니까
        {
            return;
        }
    }
}
