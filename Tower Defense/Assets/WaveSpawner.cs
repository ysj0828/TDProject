using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;

    public float waveCountDown = 10f;
    private float counter = 2f;

    private int waveIndex = 0;
    private int enemyPerWave = 1;

    public Text waveCountdownText;

    void Update()
    {
        if (counter <= 0f)
        {
            StartCoroutine(SpawnWave());
            counter = waveCountDown;
        }

        counter -= Time.deltaTime;

        waveCountdownText.text = Mathf.Floor(counter).ToString();
    }

    //0.5초 간격으로 SpawnEnemy 함수 호출 & 웨이브 + 1
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < enemyPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    //enemy prefab 생성
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(enemyPrefab, spawnPoint2.position, spawnPoint2.rotation);
        Instantiate(enemyPrefab, spawnPoint3.position, spawnPoint3.rotation);
        Instantiate(enemyPrefab, spawnPoint4.position, spawnPoint4.rotation);
    }
}
