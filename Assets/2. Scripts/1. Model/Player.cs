using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnStateHaveBeenChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        EventManager.OnStateHaveBeenChanged -= OnStateChanged;
    }

    
    float speedMalus = 1.5f;
    Vector3 startingPosition;
    bool slowingDown;

    public void SetSpeedMalus(float amount)
    {
        speedMalus = amount;
    }


    void Awake()
    {
        startingPosition = transform.position;
    }

    void OnStateChanged(GameManager.GameState newState)
    {
        switch (newState)
        {
            case GameManager.GameState.Boot:
                transform.position = startingPosition;
                slowingDown = false;
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

    void Update()
    {
        if(transform.position.z < startingPosition.z && !slowingDown)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speedMalus);
        }
        else if(slowingDown)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speedMalus * 2);
        }
    }

    IEnumerator SlowDown()
    {
        slowingDown = true;
        yield return new WaitForSeconds(2);
        slowingDown = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            other.gameObject.SetActive(false);
            StartCoroutine(SlowDown());
        }

        if (other.tag == "Goal")
        {
            GameManager.Instance.EndGame(false);
        }
    }
}
