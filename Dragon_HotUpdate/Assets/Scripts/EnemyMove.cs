using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 3;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -10 || transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
