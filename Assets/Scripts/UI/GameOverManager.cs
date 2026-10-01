using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public TMP_Text gameOverText;
    public ScoreManager scoreManager;

    public void GameOver()
    {
        gameOverMenu.SetActive(true);

        gameOverText.text = "Game Over!\nScore: " + scoreManager.currentScore;

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
