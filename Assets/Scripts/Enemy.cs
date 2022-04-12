using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject explode;
    private Rigidbody2D enemyRb;
    private GameObject player;
    private SpawnManager spawnManager;
    private PlayerController playerController;
    public AudioClip destroySound;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(spawnManager.isGameActive)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            transform.Translate(lookDirection * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            AudioSource.PlayClipAtPoint(destroySound,transform.position,1f);
            Destroy(gameObject);
            Explode();
            spawnManager.enemyCount -= 1;
            spawnManager.enemiesDestroyed++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            spawnManager.isGameActive = false;
            playerController.Explode();
            Destroy(collision.gameObject);
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(explode, transform.position, explode.transform.rotation);
    }
}
