using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

// Manages the game’s core functionality, including score tracking, level progression, and game over state.
public class GameManager : MonoBehaviour
{
    // Current player score
    public int score = 0;

    // Score thresholds for progressing to the next level
    [SerializeField] private int nextLevelScore = 20;
    [SerializeField] private int prevLevelScore = 0;

    // UI elements for displaying the score, final score, and high score
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finishScoreText;
    public TextMeshProUGUI highScoreText;

    // UI elements for game over and start screens
    public GameObject gameOverImage;
    public GameObject startImage;

    // Reference to the MonsterSpawner script to adjust spawn rates
    public MonsterSpawner monsterSpawner;

    // Start() is called before the first frame update
    public void Start()
    {
        score = 0;
        // Loads the high score
        PlayerPrefs.GetInt("High Score", 0);
        // Updates score UI
        ChangeScoreText();
        // Hides the game over screen initially
        gameOverImage.SetActive(false);
        // Pauses the game initially
        Time.timeScale = 0f;
        // Displays the start screen
        startImage.SetActive(true);
    }

    // Begins the game by resuming time and hiding the start screen
    public void StartGame()
    {
        Time.timeScale = 1f;
        startImage.SetActive(false);
    }

    // Updates the score display text
    public void ChangeScoreText()
    {
        scoreText.text = score.ToString();
    }

    // Adds points to the score, manages level progression, and reduces monster spawn time when reaching target scores
    public void AddScore()
    {
        // Increments score by 10
        score += 10;
        if (score == nextLevelScore)
        {
            // Makes monsters spawn faster
            monsterSpawner.ReduceSpawnTime();
            // Updates score target for next level
            nextLevelScore += 20;
            // Updates previous level score threshold
            prevLevelScore += 20;
        }
        Debug.Log("Add Score");
        // Updates score display
        ChangeScoreText();
    }

    // Decreases the score, manages level demotion, and increases monster spawn time when score drops below a threshold
    public void DecreaseScore()
    {
        // Decrements score by 10
        score -= 10;
        if (score < 0)
        {
            // Prevents negative score
            score = 0;
        }
        if (score < prevLevelScore)
        {
            // Slows monster spawn rate
            monsterSpawner.IncreaseSpawnTime();
            // Adjusts level progression score targets
            nextLevelScore -= 20;
            prevLevelScore -= 20;
        }
        Debug.Log("Decrease Score");
        // Updates score display
        ChangeScoreText();
    }

    // Ends the game, displays game over screen, and updates the high score if needed
    public void GameOver()
    {
        // Shows game over screen
        gameOverImage.SetActive(true);
        // Pauses the game
        Time.timeScale = 0f;
        // Retrieves stored high score
        int highScore = PlayerPrefs.GetInt("High Score");
        if (score > highScore)
        {
            // Sets new high score
            PlayerPrefs.SetInt("High Score", score);
            Debug.Log("High Score: " + score);
        }
        // Updates UI with final score and high score
        CountScore();
    }

    // Updates the final score and high score display texts
    public void CountScore()
    {
        finishScoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score");

    }

    // Restarts the game by reloading the scene
    public void Restart()
    {
        SceneManager.LoadScene("FlyMario");
    }
}