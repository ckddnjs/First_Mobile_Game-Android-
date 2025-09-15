using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public PlayerFear pFear;

    void Start()
    {
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "SampleScene")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if(scene.name == "GameOverScene")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    void Update()
    {
        if(pFear != null && pFear.maxFearPercentage == pFear.currentFearPercentage)
        {
            GameOverScene_ByFear();
            Debug.Log("������ ���� �÷��̾� ���");
        }
        
        // �÷��̾ ���Ϳ� ���� ü���� �� ���

        // �÷��̾ Ż�� �����ؼ� ���� ����
    }

    public void GameStartScene() 
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }
    public void GoToMenuScene()
    {
        SceneManager.LoadScene("StartMenuScene");
    }
    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void GameOverScene_ByFear()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("���� ����");
    }
}
