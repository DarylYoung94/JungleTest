using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance = null;
    public GameObject scene = null;
    public bool playerActive = true;
    public float bossHealth =1;
    public GameObject boss;
    public bool bossSpawned = false;
    public GameObject enemyMan;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        
    }

    public GameObject player;

    public void Update()
    {
        bossHealth = boss.GetComponent<Enemy>().health;
       bossSpawned = boss.GetComponent<BigEnemyAbilities>().bossSpawn;
        if (bossHealth <=0 && bossSpawned == true)
        {
            //SceneManager.LoadScene(2);
        }

    }      
}
