using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;
    public static GameManager Instance; 
    public GameObject StartPage;
    public GameObject GameOverPage;
    public GameObject CountdownPage;
    public GameObject HighScorePage;
    public Text scoreText;
    enum PageState { 
        None,
        start,
        gameOver,
        countdown,
        highScore
    }   
    int score = 0;
    bool gameOver = true;
    public bool GameOver { get { return gameOver; } }
    void Awake()
    {
        Instance = this;
        SetStatePage(PageState.start);
    }
    void OnEnable()
    {
        CountdownText.OnCountdownFinished += OnCountdownFinished;
        TapControl.OnPlayerDied += OnPlayerDied;
        TapControl.OnPlayerScore += OnPlayerScore;
    }
    void OnDisnable()
    {
        CountdownText.OnCountdownFinished -= OnCountdownFinished;
        TapControl.OnPlayerDied -= OnPlayerDied;
        TapControl.OnPlayerScore -= OnPlayerScore;
    }
    void OnCountdownFinished()
    {
        gameOver = false;
        SetStatePage(PageState.None);
        OnGameStarted();
        score = 0;
        
    }
    void OnPlayerDied()
    {
        int savescore = PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.SetInt("Score", score);
        Debug.Log(PlayerPrefs.GetInt("Score"));
        if (savescore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        gameOver = true;
        SetStatePage(PageState.gameOver);
    }
    void OnPlayerScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    void SetStatePage(PageState state)
    {
        switch (state)
        {
            case PageState.None:
                StartPage.SetActive(false);
                GameOverPage.SetActive(false);
                CountdownPage.SetActive(false);
                HighScorePage.SetActive(false);
                break;
            case PageState.start:
                StartPage.SetActive(true);
                GameOverPage.SetActive(false);
                CountdownPage.SetActive(false);
                HighScorePage.SetActive(false);
                scoreText.text = null;
                break;
            case PageState.gameOver:
                StartPage.SetActive(false);
                GameOverPage.SetActive(true);
                CountdownPage.SetActive(false);
                HighScorePage.SetActive(false);
                break;
            case PageState.countdown:
                StartPage.SetActive(false);
                GameOverPage.SetActive(false);
                CountdownPage.SetActive(true);
                HighScorePage.SetActive(false);
                break;
            case PageState.highScore:
                StartPage.SetActive(false);
                GameOverPage.SetActive(false);
                CountdownPage.SetActive(false);
                HighScorePage.SetActive(true);
                scoreText.text = null;
                break;
        }
    }
    public void ConfirmGameOver()
    {
        OnGameOverConfirmed();
        scoreText.text = "0";
        SetStatePage(PageState.countdown);
    }
    public void StartGame()
    {
        SetStatePage(PageState.countdown);
    }
    public void HighScore()
	{
        SetStatePage(PageState.highScore);
	}
}
