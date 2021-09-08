using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Level 
{

    #region PLAYER PARAMS

    //The amount of deceleration to apply on the player when it hits an obstacle
    public static float playerSpeedMalus = 1.8f;

    //Starting time and fire rate of Player's weapon
    public static float shootingStartingTime = 1;
    public static float fireRate = 0.2f;

    #endregion

    #region ENEMIES PARAMS

    //The number of the enemies. ( if set to 0 the spawner will spawn enemies in loop )
    public static int enemyNumber = 14;

    //Enemy spawner starting time and spawn rate
    public static float enemyStartingSpawnTime = 1;
    public static float enemySpawnRate = 0.25f;

    #endregion

    #region OBSTACLE PARAMS

    //Starting time and spawn rate of the obstacle spawner
    public static float obstacleStartingTime = 0;
    public static float obstacleSpawnRate = 3;

    #endregion

    #region OTHER

    //Position in units of the finish line
    public static int finishLinePosition = 400;

    #endregion
    
}
