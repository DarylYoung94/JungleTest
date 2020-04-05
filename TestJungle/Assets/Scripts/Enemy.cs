//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float enemyLevel = 1;

    private Vector3 look;
    public float damageTaken;
    public GameObject damagePop;
    public int experience;
    public Image healthBar;
    public GameObject healthCanvas;
    public float dropRate = 0.3f; //can change this in inspector for different enemies?
    Camera  cam;
    public float healthness;
    public float startHealth ;
    public float health =0 ;
    public GameObject enemy;
    public GameObject Loot1;
    public GameObject player;
    private AbilityManager scriptObj ;
    public GameObject[] otherScriptObj;
    public int itemIndex;
    public float dropChance ;
    public GameObject enemyManager;
    public Vector3 dmgPopLoc;
    public GameObject lootPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        healthness = startHealth + 10 * enemyLevel;
        health = healthness;
        enemy = this.gameObject;
      
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameManager.instance.player;
        scriptObj = GetComponent<AbilityManager>();
        dropChance = Random.value;

        healthCanvas.transform.LookAt(cam.transform.position);
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        damageTaken = amount;
  
        if (damagePop )
        {
            ShowDamagePop();
        }

        //show damage
        healthBar.fillAmount = health / healthness;
        if(health<=0f )
        {
            if (AbilityManager.AbilityTriggers.Count <= 0)
            {
                player.GetComponent<PlayerXP>().AddExp(experience);
               
                Die();
            }
            else
            {
                if (dropChance < dropRate)
                    //SpawnLoot();
                    Loot();
                if (Loot1 != null)
                {
                    player.GetComponent<PlayerXP>().AddExp(experience);
                    Die();
                }
            }
        }
    }
    

    void SpawnLoot()
    {
        int random = Random.Range(0, AbilityManager.AbilityTriggers.Count);
        GameObject lootDrop = AbilityManager.AbilityTriggers[itemIndex];
        itemIndex = random;

        Debug.Log(itemIndex);
        lootDrop = Instantiate(AbilityManager.AbilityTriggers[itemIndex], enemy.transform.position, Quaternion.identity) as GameObject;
        AbilityManager.AbilityTriggers.RemoveAt(itemIndex);
    }

//
public void ShowDamagePop()
    {
        GameObject DMG = Instantiate(damagePop, transform.position + (dmgPopLoc)  , Quaternion.identity);
        if(DMG != null)
        {
            DMG.GetComponent<TextMesh>().text = damageTaken.ToString();
            Debug.Log(damageTaken + " damageTaken" );
        }
            
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    public void Loot()
    {
        GameObject l;
        l = Instantiate(lootPrefab, enemy.transform.position, Quaternion.identity);


    }
}
