using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemySpawner : MonoBehaviour
{
    public float waveLevel = 1;
    public float timeBetweenWaves = 5f;       // time between camps spawning
    private float waveCountdown = 5f;            //time before camps spawn
    public Transform spawnPoint;
    public Rigidbody enemyPrefab;
    public int numberOfEnemies = 3;
    public float Speed;
    public float time;
    public GameObject player;
    public float radius;
    public float time1 = 5f;
    public bool areEnemies = true;
    public float timer = 0;
    public float spawnTimer = 10;
    public bool spawn = false;
    // Start is called before the first frame update


    void Start()
    {
        SpawnWave();
        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("ChargeEnemy");

        if (enemies.Length == 0)
        {

            timer += Time.deltaTime;
            if (timer >= spawnTimer)
            {
                spawn = true;
                timer = 0;
            }

            if (areEnemies == false && spawn == true)
            {
                SpawnWave();
                spawn = false;
                waveLevel++;
            }
        }
        enemyPrefab.GetComponent<Enemy>().enemyLevel = waveLevel;
    }

    void SpawnWave()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Rigidbody enemyInstance;
            enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity) as Rigidbody;
            enemyInstance.AddForce(-spawnPoint.forward * Speed, ForceMode.Impulse);
        }
    }
}
