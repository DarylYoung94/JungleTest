using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLoot : MonoBehaviour
{
    public GameObject player;
    private int randomIndex;
    public int totalLoots ;
    public GameObject loot;

    void Start()
    {
        player = GameManager.instance.player;
        totalLoots = player.GetComponent<PlayerManager>().totalLoots;
      
    }
     void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag ("Player"))
        {
            randomIndex = Random.Range(0, player.GetComponent<PlayerManager>().unobtainableAbilities.Count);
            Debug.Log(randomIndex);
            AssignAbility();
        }
    }
    public enum abilityNames
    {
        BOMB =0,
        WALL=1,
        ATTACKSPEED=2,
        TURRET=3,
        TOTEM=4

    }
    void AssignAbility()
    {
        int assignedAbility = player.GetComponent<PlayerManager>().unobtainableAbilities[randomIndex];
        switch ((abilityNames)assignedAbility) 

        {
            case abilityNames.BOMB:
                player.GetComponent<Abilityscript>().enabled = true;
                player.GetComponent<Abilityscript>().key = player.GetComponent<InputManager>().abilityList[0];
                player.GetComponent<InputManager>().abilityList.RemoveAt(0);
                findAbilityAndRemove(assignedAbility);
                Destroy();
                break;

            case abilityNames.WALL:
                player.GetComponent<Ability2>().enabled = true;
                player.GetComponent<Ability2>().key = player.GetComponent<InputManager>().abilityList[0];
                player.GetComponent<InputManager>().abilityList.RemoveAt(0);
                findAbilityAndRemove(assignedAbility);
                Destroy();
                break;

            case abilityNames.ATTACKSPEED:
                player.GetComponent<AttackSpeedBuff>().enabled = true;
                player.GetComponent<AttackSpeedBuff>().key = player.GetComponent<InputManager>().abilityList[0];
                player.GetComponent<InputManager>().abilityList.RemoveAt(0);
                findAbilityAndRemove(assignedAbility);
                Destroy();
                break;

            case abilityNames.TURRET:
                player.GetComponent<Ability4>().enabled = true;
                player.GetComponent<Ability4>().key = player.GetComponent<InputManager>().abilityList[0];
                player.GetComponent<InputManager>().abilityList.RemoveAt(0);
                findAbilityAndRemove(assignedAbility);
                Destroy();
                break;

            case abilityNames.TOTEM:
                player.GetComponent<Ability5>().enabled = true;
                player.GetComponent<Ability5>().key = player.GetComponent<InputManager>().abilityList[0];
                player.GetComponent<InputManager>().abilityList.RemoveAt(0);
                findAbilityAndRemove(assignedAbility);
                Destroy();
                break;

            default:
                Debug.Log("no more abilities to unlock");
                break;

        }
    }

    public int findAbilityIndex(int abilityNumber)
    {
        int index = -1;
        for (int i = 0; i < player.GetComponent<PlayerManager>().unobtainableAbilities.Count; i++)
        {
            if (player.GetComponent<PlayerManager>().unobtainableAbilities[i] == abilityNumber)
            {
                index = i;
                break;
            }
        }

        return index;
    }

   public void findAbilityAndRemove(int abilityNumber)
    {
        if (findAbilityIndex(abilityNumber) != -1)
        {
            player.GetComponent<PlayerManager>().unobtainableAbilities.RemoveAt(findAbilityIndex(abilityNumber));
        }
        Debug.Log("can't find ability in list");
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
