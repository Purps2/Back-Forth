using UnityEngine;

public class GemManager : MonoBehaviour

{
    public GemSpawner gemSpawner;
    public ScoreManager scoreManager;
    public GameOverManager gameOverManager;

    public bool leftGemActive = false;
    public bool rightGemActive = true;
    void Start()
    {
        gemSpawner.SpawnRightGem();
    }

    public void LeftGemCollected()
    {
        leftGemActive = false;
        rightGemActive = true;

        scoreManager.AddScore();

        Debug.Log("Right Gem is Falling!");

        gemSpawner.SpawnRightGem();
    }

    public void RightGemCollected()
    {
        leftGemActive = true;
        rightGemActive = false;

        scoreManager.AddScore();

        Debug.Log("Left Gem is Falling!");

        gemSpawner.SpawnLeftGem();
    }

    public void GemMissed()
    {
        leftGemActive = false;
        rightGemActive = false;

        gameOverManager.GameOver();
    }
}
