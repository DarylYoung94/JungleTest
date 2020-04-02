using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyAbilities : MonoBehaviour
{
    public GameObject enemy;
    public float enemyHealth;
    public float enemyHealth75;
    public float enemyHealth50;
    public float enemyStartHealth;
    public bool bossSpawn=true;
    // Start is called before the first frame update
     void Awake()
    {
        Debug.Log("enemy health" + enemy.GetComponent<Enemy>().health);
        enemyStartHealth =  enemy.GetComponent<Enemy>().health;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyStartHealth == 0 )
        {
            enemyStartHealth = enemy.GetComponent<Enemy>().health;
        }
        enemyHealth75 = enemyStartHealth * 0.75f;
        enemyHealth50 = enemyStartHealth * 0.5f;
        enemyHealth = enemy.GetComponent<Enemy>().health;

        if (enemyHealth <= enemyHealth75)
        {
            enemy.GetComponent<EnemyCharge>().enabled = true;
        }

        if (enemyHealth <= enemyHealth50)
        {
            enemy.GetComponent<EnemyAI>().allowAttack = true;
        }
    }   
}
