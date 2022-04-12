using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatTitleBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private float repeatheight;
    private Vector3 startPos;
    [SerializeField] float speed = 2f;
    public float currentPos;
    public float halfSize;
    public float subtractSize;
    void Start()
    {
        startPos = transform.position;
        repeatheight = GetComponent<BoxCollider2D>().size.y / 2;
        halfSize = repeatheight;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position.y;
        subtractSize = repeatheight - startPos.y;
        if (transform.position.y > repeatheight - startPos.y)
        {
            transform.position = startPos;
        }
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
