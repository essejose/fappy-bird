﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {


    public static GamePlayController instance;

    [SerializeField]
    private Text scoreText, endScore, bestScore, gameOverText;

    [SerializeField]
    private Button restartGameButton, instructionsButton;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject[] birds;

    [SerializeField]
    private Sprite[] medals;

    [SerializeField]
    private Image medalImage;

    void Awake()
    {
        MakeInstance();
         Time.timeScale = 0f;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PauseGame()
    {
        if (BirdScript.instance != null)
        {
            if (BirdScript.instance.isAlive)
            {
                pausePanel.SetActive(true);
                gameOverText.gameObject.SetActive(false);
                endScore.text = "" + BirdScript.instance.score;
                bestScore.text = "" + GameController.instance.GetHighscore();
                Time.timeScale = 0f;
                restartGameButton.onClick.RemoveAllListeners();
                restartGameButton.onClick.AddListener(() => ResumeGame());

            }
        }
    }

    public void GoToMenuButton()
    {
        SceneFader.instance.FadeIn("MainMenu");
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;

    }
    public void RestartGame()
    {
 
        SceneFader.instance.FadeIn(SceneManager.GetActiveScene().name);
    }

    public void PlayGame()
    {
        scoreText.gameObject.SetActive(true);
        birds[GameController.instance.GetSelectedBird()].SetActive(true);
        instructionsButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void PlayerDiedShowScore(int score)
    {
        AdsController.instance.ShowInterstitial();
        pausePanel.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        endScore.text = "" + score;

        if(score > GameController.instance.GetHighscore())
        {
            GameController.instance.SetHighscore(score);
 
        }

        bestScore.text = "" + GameController.instance.GetHighscore();

        if (score <= 20)
        {
            medalImage.sprite = medals[0];
        }
        else if(score > 20 && score < 40)
        {
            medalImage.sprite = medals[1];

            if(GameController.instance.isGreenBirdUnlocked() == 0)
            {
                GameController.instance.UnlockGreenBird();
            }
        }
        else
        {
            medalImage.sprite = medals[2];
            if (GameController.instance.isGreenBirdUnlocked() == 0)
            {
                GameController.instance.UnlockGreenBird();
            }

            if (GameController.instance.isRedBirdUnlocked() == 0)
            {
                GameController.instance.UnlockRedBird();
            }
        }

        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => RestartGame());
        

    }


}
