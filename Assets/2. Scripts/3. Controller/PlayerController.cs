using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float leftBound;
    float rightBound;
    float horizontalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        leftBound = -4;
        rightBound = 4;
        horizontalSpeed = 50;
    }

    void Update()
    {
        if (Input.touches.Length > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                var touch = Input.touches[i];
                if (touch.phase != TouchPhase.Began)
                {
                    transform.position = new Vector3(1, 0, 0);
                }
            }

        }

        if (Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x > Camera.main.pixelWidth/2)
            {
                if (transform.position.x < rightBound)
                {
                    transform.position = new Vector3(transform.position.x + 0.1f * horizontalSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                }
                
            }
            else
            {
                if (transform.position.x > leftBound)
                {
                    transform.position = new Vector3(transform.position.x -0.1f * horizontalSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                }
            }
        }
    }


}
