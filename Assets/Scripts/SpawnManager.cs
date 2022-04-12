using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject gameOverScreen;
    public GameObject gameUI;
    public GameObject Player;
    public TextMeshProUGUI endGameDestroyedText;
    public bool isGameActive;
    public bool isGamePaused;
    public int enemyCount;
    public TextMeshProUGUI destroyedText;
    public TextMeshProUGUI waveText;
    public int enemiesDestroyed;
    private int spawnTopOrBottom;
    private float yMax = 7;
    private float yMin = 1.5f;
    private float[] xRange = new float[] {-19f,19f};
    private int waveNumber;
    // Start is called before the first frame update

    public void Start()
    {
        waveNumber = 0;
        isGameActive = true;
        isGamePaused = false;
        enemyCount = 0;
        Player.SetActive(true);
        gameUI.SetActive(true);
    }

    // Update is called once per frame

    void Update()
    {   
        destroyedText.text = "destroyed " + enemiesDestroyed;
        if(isGameActive && enemyCount == 0)
        {
            waveNumber++;
            waveText.text = "Wave: " + waveNumber;
            int enemiesToSpawn = waveNumber * 2;
            for(int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
                enemyCount++;
            }
        }
        if(!isGameActive)
        {
            GameOver();
        }
    }


    private void SpawnEnemy()
    {
        spawnTopOrBottom = Random.Range(0,2);
        if (spawnTopOrBottom == 1)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(xRange[0],xRange[1]), yMax, 0), enemyPrefab.transform.rotation);
        }
        else
        {
            Instantiate(enemyPrefab, new Vector3(xRange[Random.Range(0,2)], Random.Range(yMin, yMax), 0), enemyPrefab.transform.rotation);
        }
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
        endGameDestroyedText.text = "Destroyed " + enemiesDestroyed + " " + "targets";
        gameUI.SetActive(false);
        StartCoroutine(GameReloadCourtine());
        
    }

    IEnumerator GameReloadCourtine()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("TitleScene",LoadSceneMode.Single);
    }
}
