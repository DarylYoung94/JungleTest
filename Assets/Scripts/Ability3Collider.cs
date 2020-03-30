using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability3Collider : MonoBehaviour
{
    public GameObject buffZone;

    private void Start()
    {
        buffZone = this.gameObject;
    }
    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "AtkSpd")
        {
            if (buffZone != null)
            {
                BasicAttack PlayerInZone = collision.transform.GetComponent<BasicAttack>();
                if (PlayerInZone != null)
                {
                    Debug.Log("attack speed buff!");
                    PlayerInZone.cooldownTime = 0.5f;
                }
            }
        }
    }
}


           
    