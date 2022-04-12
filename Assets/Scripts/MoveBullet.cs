using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    private float speed = 10;
    private float yBounds = 8f;
    private float xBounds = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        if (transform.position.x > xBounds || transform.position.x < -xBounds)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > yBounds || transform.position.y < -yBounds)
        {
            Destroy(gameObject);
        }
    }

}
