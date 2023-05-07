using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score=0;
    public TextMeshProUGUI gameoverText;
    public Button restartButton;

    public bool isGameActive;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        score = 0;
        UpdateScore(0);
        spawnRate /= diffculty;

        isGameActive = true;
        StartCoroutine(SpawnTarget());
        titleScreen.gameObject.SetActive(false);
    }
}
