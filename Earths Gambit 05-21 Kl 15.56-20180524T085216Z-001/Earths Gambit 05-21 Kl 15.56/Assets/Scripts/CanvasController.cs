using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public static CanvasController canvasControllerInstance;
    public Text livesText;
    public Slider healthSlider;
    public Image Fill;
    public Text scoretext;
    private int score;
    public float playerHealth = 100f;
    public Text Gameovertext;
    public Text RestartText;
    public GameObject RestartButton;
    public Vector3 v;
    public Animator fader;
    public Image black;
    public Transform restartposition;
    private bool gameOver;
    private bool restart;

    private float lifeMid = 40f;
    private float lifeCritical = 10f;
    private Quaternion cameraStable;

    void Start()
    {
        gameOver = false;
        restart = false;
        RestartText.text = "";
        Gameovertext.text = "";
        score = 0;
        UpdateScore();
        canvasControllerInstance = this;
        healthSlider.wholeNumbers = true;
        healthSlider.minValue = 0f;
        healthSlider.maxValue = 100f;
    }

    void Update()
    {
        GameObject Player = GameObject.Find("Player");
        if (gameOver)
        {
            RestartText.text = "press to restart";
            restart = true;
        }
        if (restart)
        {
            Debug.Log("restart");
            RestartButton.transform.position = restartposition.position;
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }

        }

        if (Player != null)
        {
            // livesText.text = "x" + GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>().lives;
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>().health;
            healthSlider.value = playerHealth;
        }
        if (playerHealth <= lifeCritical)
        {
            Fill.color = Color.red;
        }
        else if (playerHealth <= lifeMid)
        {
            Fill.color = Color.yellow;
        }
        else
        {
            Fill.color = Color.blue;
        }

        // playerHealth--;
    }
    public void addScore(int ScoreValue)
    {
        Debug.Log("add score");
        score += ScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        if (score != null)
        {
            scoretext.text = "Score: " + score;
        }
    }
    public void GameOver()
    {
        Gameovertext.text = "Game Over! Your Score was: " + score;
        gameOver = true;
        Destroy(scoretext);
    }
    public void RestartGame(){
        Application.LoadLevel(Application.loadedLevel);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public int getScore()
    {
        return score;
    }



}