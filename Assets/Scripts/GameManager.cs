using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    private int score=0;
    public TextMeshProUGUI gameoverText;
    public Button restartButton;

    public bool isGameActive;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public int lives;
    public GameObject titleScreen;
    public GameObject pauseScreen;

    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isGameActive)
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Set the time scale to 0 to pause the game
        isPaused = true;
        pauseScreen.gameObject.SetActive(true);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Set the time scale back to 1 to resume the game
        isPaused = false;
        pauseScreen.gameObject.SetActive(false);

    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }
    public void UpdateLives(int livesToAdd)
    {
        if (lives >= 1)
        {
            lives -= livesToAdd;
        }
        livesText.text = "Lives: " + lives;
        if (lives < 1)
        {
            GameOver();
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = " Score:" + score;
    }
    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 
    }
    public void StartGame(int diffculty)
    {
        isPaused = false;
        score = 0;
        UpdateScore(0);
        spawnRate /= diffculty;
        lives = 5;
        UpdateLives(0);
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        livesText.gameObject.SetActive(true);
    }
}
