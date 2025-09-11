using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; // ���ٿ�

    [Header("���� �÷��� ����")]
    [Tooltip("���� ���� �� �帥 �ð�(��)")]
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

        DontDestroyOnLoad(gameObject); // �� �ٲ�� ������Ʈ ���� x @@@@@
    }

    void Start()
    {
        
    }

    void Update()
    {
        gamePlayTime += Time.deltaTime;
    }
}
