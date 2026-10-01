using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public int currentScore = 0;

    public void AddScore()
    {
        currentScore += 5;

        scoreText.text = "Score: " + currentScore;

        Debug.Log("Score: " + currentScore);
    }

}
