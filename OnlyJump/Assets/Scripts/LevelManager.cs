using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public event EventHandler OnGameOver;

    private int currentGainCoins;
    private GameState gameState;
   
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start() 
    {
        gameState = GameState.Play;
        GameManager.Instance.OnStatsUpdated += GameManager_OnStatsUpdated;
        GameManager.Instance.OnCompleteLevel += GameManager_OnCompleteLevel;

        Coin.OnRaised += Coin_OnRaised;    
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnStatsUpdated -= GameManager_OnStatsUpdated;
        GameManager.Instance.OnCompleteLevel -= GameManager_OnCompleteLevel;

        Coin.OnRaised -= Coin_OnRaised;
    }

    private void Coin_OnRaised(object sender, EventArgs e) => currentGainCoins++;

    private void GameManager_OnCompleteLevel(object sender, EventArgs e)
    {
        SetGameState(GameState.LevelComplete);
        GameManager.Instance.CheckLevelResult(currentGainCoins);
    }

    private void GameManager_OnStatsUpdated(object sender, EventArgs e) => 
        GameManager.Instance.UpdateAmountOfCoins(currentGainCoins);

    public void SetGameState(GameState state)
    {
        if(state == GameState.GameOver) 
            OnGameOver?.Invoke(this, EventArgs.Empty);

        gameState = state;
    }

    public bool IsPlayState() => gameState == GameState.Play;

    public bool IsPauseState() => gameState == GameState.Pause;

    public void RepeatLevel()
    {
        LoaderScene.LoadTheSameScene();
        GameManager.Instance.UpdateStatistic();
        Time.timeScale = 1f;
    }

}
public enum GameState
{
    LevelComplete,
    GameOver,
    Pause,
    Play
}