using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; // 접근용

    [Header("게임 플레이 정보")]
    [Tooltip("게임 시작 후 흐른 시간(초)")]
    public float gamePlayTime = 0f;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); // 씬 바뀌에도 오브젝트 삭제 x @@@@@
    }

    void Start()
    {
        
    }

    void Update()
    {
        gamePlayTime += Time.deltaTime;
    }
}
