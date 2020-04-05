using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    public GameObject totem;
    public float totemRange;
    public float closestEnemy;
    Transform bestTarget = null;
    public GameObject bullet;
    public GameObject totemFirePoint;
    public Rigidbody bulletRB;
    public float totemBulletSpeed;
    public float timer;
    public float totemAttackSpeed = 1f;
    public bool shot;
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            FindClosestEnemy();
            TurretShot();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        
    
    
    
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("totem hit1");
            if (totem !=null)
            {
                Debug.Log("totem hit2");
                FindClosestEnemy();
                TurretShot();
            }
           
        }
    }

    public void FindClosestEnemy()
    {

        Vector3 totemPosition = totem.transform.position;
        closestEnemy = Mathf.Infinity;
        Collider[] colliders = Physics.OverlapSphere(totemPosition, totemRange);

        foreach (Collider hit in colliders)
        {

            float distToEnemy = Vector3.Distance(hit.transform.position, totemPosition);
            Enemy enemyHit = hit.transform.GetComponent<Enemy>();


            if (enemyHit != null && distToEnemy < closestEnemy)
            {
                closestEnemy = distToEnemy;
                bestTarget = enemyHit.transform;
            }
        }

    }
    public void TurretShot()
    {
        GameObject turretBulletInstance;
        turretBulletInstance = Instantiate(bullet, totemFirePoint.transform.position, Quaternion.identity);
        bulletRB = turretBulletInstance.GetComponent<Rigidbody>();
        bulletRB.transform.LookAt(bestTarget);
        bulletRB.AddForce(bulletRB.transform.forward * totemBulletSpeed, ForceMode.Impulse);

    }
}
