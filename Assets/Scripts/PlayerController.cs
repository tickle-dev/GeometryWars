using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject gun;
    public GameObject playerExplode;
    public AudioClip playerExplodeAudio;
    public GameObject pauseMenu;
    [SerializeField] float force = 50;
    private float verticalInput;
    private float horizontalInput;
    Rigidbody2D playerRb;
    private SpawnManager spawnManager;
    private AudioSource laserSound;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(bulletPrefab.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        laserSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnManager.isGameActive)
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
            GetMovement();
            GetRoation();
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }  
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                spawnManager.isGamePaused = !spawnManager.isGamePaused;
                pauseMenu.SetActive(spawnManager.isGamePaused);
                Time.timeScale = (spawnManager.isGamePaused) ? 0 : 1;
            }
        }
    }

    void GetMovement()
    {
        //Add force depending on input pressed
        playerRb.AddForce(Vector2.up * verticalInput * force);
        playerRb.AddForce(Vector2.right * horizontalInput * force);
    }

    void GetRoation()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }

    void Shoot()
    {
        laserSound.Play();
        Instantiate(bulletPrefab, gun.transform.position, transform.rotation);
    }
    
    public void Explode()
    {
        Instantiate(playerExplode, transform.position, playerExplode.transform.rotation);
        AudioSource.PlayClipAtPoint(playerExplodeAudio, transform.position);
    }
}
