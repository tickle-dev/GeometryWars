using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStars : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startPos;
    public float speed;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(transform.position.y > Mathf.Abs(startPos.y) * 2)
        {
            transform.position = startPos;
        }
        
    }
}
