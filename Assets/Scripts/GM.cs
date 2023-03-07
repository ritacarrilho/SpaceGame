using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public int score;
    public Timer timer;
    public TextMeshProUGUI scoreText;
    public bool isPlaying = true;
    public GameObject gameOverPopup;
    public GameObject gameWinPopup;
    public GameObject austronaut;
    //public Text gameOverText;
    //public GameObject replayBtn;

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        isPlaying = true;
    }


    public void AddPoints(Collider2D collectedObject)
    {
        switch (collectedObject.name)
        {
            case "Satellite":
                score += 2;
                break;
            case "Ruby":
                score += 1;
                break;
            case "Gold":
                score += 5;
                break;
            case "Metal":
                score += 3;
                break;
        }
        scoreText.text = "Score: " + score.ToString();
    }
    
    void Awake() {
        //gameOverPopup = GameObject.Find("GameOverCanvas");
        gameOverPopup.SetActive(false);

        //gameWinPopup = GameObject.Find("GameWinCanvas");
        gameWinPopup.SetActive(false);

        //replayBtn = GameObject.Find("ReplayBtn");
        //replayBtn.SetActive(false);
    }
    public void GameOver()
{
    isPlaying = false;
    Time.timeScale = 0;
    gameOverPopup.SetActive(true);
    Destroy(austronaut);
    //replayBtn.SetActive(true);
}

    /*public void replayBtn_Click(){ 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isPlaying = true;
        timer.Update();
    } */
    
    public void GameWin()
    {
        isPlaying = false;
        if (!isPlaying)
        {
            Time.timeScale = 0;
            gameWinPopup.SetActive(true);
            Destroy(austronaut);
        }
    }    
}
