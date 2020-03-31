using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    public float Damage = 10f;
    public float radius = 10f;
    public float power = 100f;
    public float upForce = 2f;
    public float time = 3f;
    public float bombDuration = 3.5f;
    public bool hasExploded ;
    
    // Start is called before the first frame update
    void Start()
    {
        hasExploded = false;
        StartCoroutine(ExecuteAfterTime(time));
        
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        
        DetonateLate();
        Destroy(this.gameObject);
    } 
    


        public void DetonateLate()
    {
        Vector3 explosionPosition = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);

            }
            Enemy enemyHit = hit.transform.GetComponent<Enemy>();
            if (enemyHit != null)
            {
                enemyHit.TakeDamage(Damage);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (hasExploded == true)
        {
            StopCoroutine(ExecuteAfterTime(time));
        }
    }
}
