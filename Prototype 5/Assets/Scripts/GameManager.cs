using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public GameObject scoreText;
    public GameObject gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    // Start is called before the first frame update
    public void startGame(int difficulty)
    {
        StartCoroutine(SpawnTarget());
        score = 0;

        spawnRate /= difficulty;
        scoreText.GetComponent<TextMeshPro>().text = "etiketė: " + score;
        UpdateScore(0);
        isGameActive = true;
        titleScreen.SetActive(false);
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
            UpdateScore(5);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.GetComponent<TextMeshPro>().text = "etiketė: " + score;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
