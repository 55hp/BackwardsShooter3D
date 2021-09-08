using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public static class EventManager 
{
    public delegate void OnStateChangeHandler(GameState newState);
    public static event OnStateChangeHandler OnStateHaveBeenChanged;


    public static void ChangeGameState(GameState newState)
    {
        EventManager.OnStateHaveBeenChanged?.Invoke(newState);
    }

}
