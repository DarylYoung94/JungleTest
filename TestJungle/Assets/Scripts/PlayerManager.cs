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
    public Image ExpBar;
    public float EXP;
    public float EXP2;
    public Text healthText;
    public Text expText;
    public Text levelText;
    public float lvl;
    public List<int> unobtainableAbilities;
    public int totalLoots = 5 ;
    public bool canTakeDamage=true;

    // Start is called before the first frame update
    void Start()
    {
        for( int i=0; i<totalLoots; i++)
        {
            unobtainableAbilities.Add(i);
        }


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
        EXP = player.GetComponent<PlayerXP>().exp;
        EXP2 = player.GetComponent<PlayerXP>().expToNextLevel;
        lvl = player.GetComponent<PlayerXP>().level;
        ExpBar.fillAmount = EXP / EXP2;
        healthText.text = health.ToString() + "/" + maxHealth.ToString();
        expText.text = EXP.ToString() + "/" + EXP2.ToString();
        levelText.text =  "Level " + lvl.ToString();
    }

    public void TakeDamage(float amount)
    {
        if (canTakeDamage)
        {
            health -= amount;
            healthBar.fillAmount = health / maxHealth;
            if (health <= 0f)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
