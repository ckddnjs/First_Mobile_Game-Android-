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
            Debug.Log("공포로 인해 플레이어 사망");
        }
        
        // 플레이어가 몬스터에 의해 체력이 깎여 사망

        // 플레이어가 탈출 성공해서 게임 오버
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
        Debug.Log("게임 종료");
    }
}
