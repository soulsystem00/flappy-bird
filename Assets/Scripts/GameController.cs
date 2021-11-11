using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState { Playable, Pause, }
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] Text gameOverText;
    [SerializeField] Text gameOverScore;
    [SerializeField] ScoreScript scoreText;
    [SerializeField] Button btnRestart;
    GameState state = GameState.Playable;
    private void Awake()
    {
        playerMove.OnGameOver += () => 
        { 
            state = GameState.Pause;
            gameOverText.gameObject.SetActive(true);
            btnRestart.gameObject.SetActive(true);
            gameOverScore.gameObject.SetActive(true);
            gameOverScore.text = scoreText.Score.ToString();
            Time.timeScale = 0f;
        };
        btnRestart.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Main");
        });
    }
    private void Update()
    {
        if (state == GameState.Playable)
            playerMove.HandleUpdate();
    }
}
