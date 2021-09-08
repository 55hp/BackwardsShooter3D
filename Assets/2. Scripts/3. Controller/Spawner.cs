using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] int amountToPool = 20;

    List<GameObject> pooledObjects;

    int amountToSpawn = 0;
    float startingTime = 0;
    float spawnRate = 0;
    
    IEnumerator spawner;

    private void OnEnable()
    {
        EventManager.OnStateHaveBeenChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        EventManager.OnStateHaveBeenChanged -= OnStateChanged;
    }

    void OnStateChanged(GameManager.GameState newState)
    {
        switch (newState)
        {
            case GameManager.GameState.Boot:
                pooledObjects = new List<GameObject>();
                for (int i = 0; i < amountToPool; i++)
                {
                    GameObject obj = (GameObject)Instantiate(prefabToSpawn);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                }

                if(amountToSpawn == 0)
                {
                    spawner = LoopSpawner();
                }
                else
                {
                    spawner = FixedAmountSpawner(amountToSpawn);
                }
                break;
            case GameManager.GameState.Play:
                StartCoroutine(spawner);
                break;
            case GameManager.GameState.Pause:

                break;
            case GameManager.GameState.Gameover:
                StopCoroutine(spawner);
                CleanStage();
                break;
            case GameManager.GameState.Win:
                StopCoroutine(spawner);
                CleanStage();
                break;
        }
    }


    /// <summary>
    /// This method spawns objects in loop starting after a fixed amount of time.
    /// </summary>
    /// <returns></returns>
     IEnumerator LoopSpawner()
    {
        yield return new WaitForSeconds(startingTime);
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    /// <summary>
    /// Spawns a specific amount of objects after a fixed amount of time.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
     IEnumerator FixedAmountSpawner(int amount)
    {
        yield return new WaitForSeconds(startingTime);
        while (amount > 0)
        {
            Spawn();
            amount--;
            yield return new WaitForSeconds(spawnRate);
        }
    }

    /// <summary>
    /// Spawns the first selectable object in the pool
    /// </summary>
     void Spawn()
    {
        GameObject obj = GetPooledObj();
        obj.transform.position = gameObject.transform.position;
        obj.transform.rotation = gameObject.transform.rotation;
        obj.SetActive(true);

    }

     GameObject GetPooledObj()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    void CleanStage()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
             pooledObjects[i].SetActive(false);
        }
    }

    public void SetStartingTime(float amount)
    {
        startingTime = amount;
    }

    public void SetSpawnRate(float amount)
    {
        spawnRate = amount;
    }
    
    public void SetAmountToSpawn(int amount)
    {
        amountToSpawn = amount;
    }

}
