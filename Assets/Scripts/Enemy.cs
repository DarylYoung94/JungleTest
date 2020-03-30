//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    private Vector3 look;
    public float damageTaken;
    public GameObject damagePop;
    //add bool for marks of abilities here
    public Image healthBar;
    public GameObject healthCanvas;
    public float dropRate;
    Camera  cam;
    public float startHealth = 50f;
    public float health ;
    public GameObject enemy;
    public GameObject Loot1;
    public GameObject player;
    private AbilityManager scriptObj ;
    public GameObject[] otherScriptObj;
    public int itemIndex;
    public float dropChance ;
    //public int ItemIndex;
    // Start is called before the first frame update
    void Start()
    {
        
       
        enemy = this.gameObject;
        health = startHealth;
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
       //damageTaken = enemy.gameObject.GetComponent<Enemy>().damageTaken;
        if (damagePop )
        {
            ShowDamagePop();
        }

        

        //show damage
        healthBar.fillAmount = health / startHealth;
        if(health<=0f )
        {
            if (AbilityManager.AbilityTriggers.Count <= 0)
            {
                Die();
            }
            else
            {
                if (dropChance>dropRate)
                SpawnLoot();
                if (Loot1 != null)
                {
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
        GameObject DMG = Instantiate(damagePop, transform.position + (Vector3.up * 2.5f)  , Quaternion.identity);
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

}
