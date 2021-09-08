using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int healthPoints = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            other.gameObject.SetActive(false);
            healthPoints--; 
            if(healthPoints < 0)
            {
                gameObject.SetActive(false);
                LevelManager.Instance.EnemyHasBeenKilled();
            }
        }

        if (other.tag == "PlayerArea")
        {
            GameManager.Instance.EndGame(true);
        }
    }
}
