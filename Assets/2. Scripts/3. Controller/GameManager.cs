using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        Boot,
        Play,
        Pause,
        Gameover,
        Win
    }

    GameState activeState;

    private void Start()
    {
        StartGame();
    }
    

    private void SetState(GameState newState)
    {
        activeState = newState;
        EventManager.ChangeGameState(activeState);
    }

    public GameState GetState()
    {
        return activeState;
    }

    /// <summary>
    /// The next methods calls the ChangeGameState event to run in another game state.
    /// </summary>
    public void StartGame()
    {
        EventManager.ChangeGameState(GameState.Boot);
        activeState = GameState.Boot;
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        EventManager.ChangeGameState(GameState.Play);
        activeState = GameState.Play;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        EventManager.ChangeGameState(GameState.Pause);
        activeState = GameState.Pause;
    }

    public void EndGame(bool gameOver)
    {
        if (!gameOver)
        {
            EventManager.ChangeGameState(GameState.Win);
            activeState = GameState.Win;
            Time.timeScale = 0;
        }
        else
        {
            EventManager.ChangeGameState(GameState.Gameover);
            activeState = GameState.Gameover;
            Time.timeScale = 0;
        }
    }

}