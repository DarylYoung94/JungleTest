using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    public GameObject player;
    public Rigidbody bulletPrefab;
    public float autoDamage;
    public float dmgScale;

     void Start()
    {
        player = GameManager.instance.player;
        dmgScale = player.GetComponent<PlayerXP>().level*2 - 1;
        autoDamage = 7 + dmgScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "RangedEnemy1" || collision.gameObject.tag == "ChargeEnemy")
        {
            if(bulletPrefab !=null)
            {
                Enemy enemyHit = collision.transform.GetComponent<Enemy>();
                if (enemyHit!=null)
                {
                    enemyHit.TakeDamage(autoDamage);
                }
               
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

   

}
