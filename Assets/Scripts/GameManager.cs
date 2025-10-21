using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private EnemyManager _enemyManager;

    public void LoadSceneLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GameOver()
    {
        panelGameOver.SetActive(true);
        _enemyManager.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    
}
