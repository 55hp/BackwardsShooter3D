using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] float constantSpeed;
    [SerializeField] float minXAxisSpawnPosition;
    [SerializeField] float maxXAxisSpawnPosition;

    void Start()
    {
        if(minXAxisSpawnPosition != 0 || maxXAxisSpawnPosition != 0)
        transform.position = new Vector3(Random.Range(minXAxisSpawnPosition, maxXAxisSpawnPosition), transform.position.y, transform.position.z);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * constantSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Deadzone")
        {
            gameObject.SetActive(false);
        }
    }
}
