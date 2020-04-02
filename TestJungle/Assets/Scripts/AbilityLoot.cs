using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLoot : MonoBehaviour
{
    public GameObject player;
    private int randomIndex;
    public int totalLoots = 4;
    public List<int> lootNumber = new List<int>();
    public GameObject loot;

    void Start()
    {
      for (int i = 0; i < totalLoots; i++)
        {
            lootNumber.Add(i);
        }
    }
     void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag ("Player"))
        {
            randomIndex = Random.Range(0, totalLoots);
            Debug.Log(randomIndex);
            AssignAbility();
        }
    }
    void AssignAbility()
    {
        switch(randomIndex)
        {
            case 3:
                player.GetComponent<Abilityscript>().enabled = true;
                lootNumber.RemoveAt(0);
                break;

            case 2:
                player.GetComponent<Ability2>().enabled = true;
                lootNumber.RemoveAt(1);               
                break;

            case 1:
                player.GetComponent<AttackSpeedBuff>().enabled = true;
                lootNumber.RemoveAt(2); 
                 break;

            default:
                Debug.Log("no more abilities to unlock");
                break;
                
        }
    }

   
}
