using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCollider :MonoBehaviour
{
   
    public GameObject explosionParticles;
    public float time = 3f;
    public float radius = 10f;
    public float power = 10f;
    public float upForce = 2f;
    public Rigidbody BombPrefab;
    public float Damage = 10f;
    // Start is called before the first frame update
    private void Start()
    {
       
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Detonate();
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ability12")
        {
            
                Debug.Log("Wall hit with bomb.");
                radius = 20f;
                Detonate();
                Destroy(this.gameObject);
            
        }

        if (collision.gameObject.tag == "Terrain")
        {
            StartCoroutine(ExecuteAfterTime(time));
           
        }
         Enemy enemyHit = collision.transform.GetComponent<Enemy>();
        if (enemyHit !=null)
        {
       
            Detonate();
            Destroy(this.gameObject);            
        }

    }

    public void Detonate()
    {
        if (BombPrefab != null)
        {
            GameObject expParticles;
            expParticles = Instantiate (explosionParticles.gameObject, BombPrefab.transform.position , Quaternion.identity );

            Vector3 explosionPosition = BombPrefab.transform.position;
            //instantiate particle effects


            Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
                
            foreach (Collider hit in colliders)
            {
                
                    Enemy enemyHit = hit.transform.GetComponent<Enemy>();
                if (enemyHit != null)
                {
                    enemyHit.TakeDamage(Damage);
                    Destroy(BombPrefab);
                }
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                 
                    rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                    
                   
                }
                
            }
        }
    }
}
