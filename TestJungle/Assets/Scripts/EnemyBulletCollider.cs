using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollider : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public float autoDamage;
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player hit");
            if (bulletPrefab != null)
            { 
                PlayerManager playerHit = collision.transform.GetComponent<PlayerManager>();
                if (playerHit != null)
                {
                    Debug.Log("take damage");
                    playerHit.TakeDamage(autoDamage);
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
