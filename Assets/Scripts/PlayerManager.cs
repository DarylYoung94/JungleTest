using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public float health;
    public float startHealth = 100;
    public Image healthBar;
    public GameObject healthCanvas;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        player.GetComponent<Abilityscript>().enabled = false;
        player.GetComponent<Ability2>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;    
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
