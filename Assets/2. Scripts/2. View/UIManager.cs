using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    
    [SerializeField] GameObject mainScreen , gameOverScreen , winScreen;
    [SerializeField] Text timerTextField;
    float counter;

    void Update()
    {
        if (GameManager.Instance.GetState() == GameManager.GameState.Play)
        {
            counter += Time.deltaTime;
            timerTextField.text = counter.ToString("000.0");
        }
    }

    void OnEnable()
    {
        EventManager.OnStateHaveBeenChanged += OnStateChanged;
    }

    void OnDisable()
    {
        EventManager.OnStateHaveBeenChanged -= OnStateChanged;
    }


    void OnStateChanged(GameManager.GameState newState)
    {
        switch (newState)
        {
            case GameManager.GameState.Boot:
                mainScreen.SetActive(true);
                counter = 0;
                break;
            case GameManager.GameState.Play:
                break;
            case GameManager.GameState.Pause:
                break;
            case GameManager.GameState.Gameover:
                gameOverScreen.SetActive(true);
                break;
            case GameManager.GameState.Win:
                winScreen.SetActive(true);
                break;
        }
    }
}
