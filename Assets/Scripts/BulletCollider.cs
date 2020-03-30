using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public float autoDamage;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "RangedEnemy1")
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
