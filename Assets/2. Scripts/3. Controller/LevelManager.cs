using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{

    [SerializeField] Spawner enemySpawner;
    [SerializeField] Spawner obstacleSpawner;
    [SerializeField] GameObject player;
    [SerializeField] GameObject finishLine;
    
    int enemies;
    
    private void OnEnable()
    {
        EventManager.OnStateHaveBeenChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        EventManager.OnStateHaveBeenChanged -= OnStateChanged;
    }

    public void OnStateChanged(GameManager.GameState newState)
    {
        switch (newState)
        {
            case GameManager.GameState.Boot:
                player.GetComponent<Player>().SetSpeedMalus(Level.playerSpeedMalus);
                player.GetComponent<Spawner>().SetStartingTime(Level.shootingStartingTime);
                player.GetComponent<Spawner>().SetSpawnRate(Level.fireRate);
                
                enemies = Level.enemyNumber;

                enemySpawner.SetAmountToSpawn(Level.enemyNumber);
                enemySpawner.SetStartingTime(Level.enemyStartingSpawnTime);
                enemySpawner.SetSpawnRate(Level.enemySpawnRate);
                
                obstacleSpawner.SetStartingTime(Level.obstacleStartingTime);
                obstacleSpawner.SetSpawnRate(Level.obstacleSpawnRate);

                finishLine.transform.position = new Vector3(finishLine.transform.position.x, finishLine.transform.position.y, Level.finishLinePosition);

                break;
            case GameManager.GameState.Play:
                break;
            case GameManager.GameState.Pause:
                break;
            case GameManager.GameState.Gameover:

                break;
            case GameManager.GameState.Win:

                break;
        }
    }
    
    public void EnemyHasBeenKilled()
    {
        enemies--;
        if(enemies < 1)
        {
            GameManager.Instance.EndGame(false);
        }
    }




}
