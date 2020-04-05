using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    public Turret turretscript;
    public GameObject player;
    public Rigidbody bulletPrefab;
    public float autoDamage;
    public float dmgScale;
    public float Damage;
     void Start()
    {
        player = GameManager.instance.player;
        dmgScale = player.GetComponent<PlayerXP>().level*2 - 1;
        autoDamage = Damage + dmgScale;
        Destroy(this.gameObject, 5);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "RangedEnemy1" || collision.gameObject.tag == "ChargeEnemy" )
        {
            if (bulletPrefab != null)
            {
                Enemy enemyHit = collision.transform.GetComponent<Enemy>();
                Totem totemHit = collision.transform.GetComponent<Totem>();
                if (enemyHit != null)
                {
                    enemyHit.TakeDamage(autoDamage);
                }
                if (totemHit != null)
                {
                    Debug.Log("Totem Hit1");
                    collision.transform.GetComponent<Totem>().shot = true;
                    
                    collision.transform.GetComponent<Totem>().shot = false;
                }

                Destroy(this.gameObject);
            }
        }
        /* if (collision.gameObject.tag == ("Totem")) //why no work
         {
            if (bulletPrefab != null)
            {
                Totem totemHit = collision.transform.GetComponent<Totem>();
                totemHit.FindClosestEnemy();
                totemHit.TurretShot();
                //collision.transform.GetComponent<Totem>().shot = true;
                Debug.Log("Totem Hit2");
                //collision.transform.GetComponent<Totem>().shot = false;
             
                

            }
    
        }
         */
        else
        {
            Destroy(this.gameObject);
        }
    }
}
