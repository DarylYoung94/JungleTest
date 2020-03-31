using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public float health;
    public float startHealth = 90;
    public Image healthBar;
    public GameObject healthCanvas;
    public float maxHealth;
    public float leveledHealth;
    // Start is called before the first frame update
    void Start()
    {
        //maxHealth = startHealth;
        maxHealth = startHealth + (player.GetComponent<PlayerXP>().level * 10);

        
        health = maxHealth;
        player.GetComponent<Abilityscript>().enabled = false;
        player.GetComponent<Ability2>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        maxHealth = startHealth + (player.GetComponent<PlayerXP>().level * 10);
       
    }

    public void TakeDamage(float amount)
    {
       
        health -= amount;
        healthBar.fillAmount = health / maxHealth;    
        if(health<=0f)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
