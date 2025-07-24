using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //GameManager SCript Instance

    public int score = 0;
    public int lives = 3;

    public bool gameOver = false;

    public TMP_Text scoreText;
    public TMP_Text livesText;

    [SerializeField]
    private GameObject gameOverpanel;

    [Header("Action Text")]
    public GameObject actionText;

    [SerializeField]
    List<String> negativeAction= new List<string> { "Oops", "Uh-Oh", "Missed" };
    [SerializeField]
    List<string> lostAction = new List<string> { "Try Again", "Defeated", "Game Over", "You lost" };

    void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void AddScore(int amount)
    {
        if (gameOver)
            return; //return when game is over
            
        score += amount;
        scoreText.text = "Score:" + score.ToString();
        //Debug.Log("Score: " + score);
    }

    public void LoseLife()
    {
        if (gameOver)
            return; //return when game is over

        lives--;
        livesText.text = "Lives:" + lives.ToString();

        if (lives <= 0)
        {
            gameOver = true;
            gameOverpanel.SetActive(true);
            StartCoroutine(ActionTextAnimation());
            TMP_Text textActionText = actionText.GetComponent<TextMeshProUGUI>();
            if (textActionText != null)
            {
                textActionText.text = lostAction[UnityEngine.Random.Range(0, 4)];
            }
            //Time.timeScale = 0f;

        }
        else
        {
            StartCoroutine(ActionTextAnimation());
            TMP_Text textActionText = actionText.GetComponent<TextMeshProUGUI>();
            if (textActionText != null)
            {
                textActionText.text = negativeAction[UnityEngine.Random.Range(0, 3)];
            }

        }
    }

    public void RestartLevel()
    {

        // Reset all pooled objects
        ObjectPooler.Instance.ResetAllPooledObjects();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator ActionTextAnimation() //Coroutine to implement UI text
    {
        actionText.SetActive(true);
        yield return new WaitForSeconds(1f);
        actionText.SetActive(false);
    }
}
