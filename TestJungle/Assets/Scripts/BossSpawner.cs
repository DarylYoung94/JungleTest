using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject player;
    public Transform bossSpawnPoint;
    public float level;
    public bool isSpawned = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        level = player.GetComponent<PlayerXP>().level;
        if (level >= 5 && isSpawned == false)
        {
            SpawnBoss();
           isSpawned = true;
        }
    }
    void SpawnBoss()
    {
        GameObject bossInstance;
        bossInstance = Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
    }
}
