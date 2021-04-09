using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnLocation;

    public float waveCountDown = 10f;
    private float counter = 2f;

    private int waveIndex = 0;
    private int enemyPerWave = 10;



    void Update()
    {
        if (counter <= 0f)
        {
            StartCoroutine(SpawnWave());
            counter = waveCountDown;
        }

        counter -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < enemyPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation);
    }
}
