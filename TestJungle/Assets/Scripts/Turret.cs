using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject turret;
    public float turretRange;
    public float closestEnemy;
    Transform bestTarget = null;
    public GameObject bullet;
    public GameObject turretFirePoint;
    private Rigidbody bulletRB;
    public float turretBulletSpeed;
    private float timer ;
    public float turretAttackSpeed = 1f;

    public void Update()
    {

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(timer < 0 )
        {
            timer = 0;
        }

        if (timer == 0)
        {
            FindClosestEnemy();
            if (bestTarget != null)
            {
                TurretShot();
                Debug.Log(bestTarget.name);
                
            }
          timer = turretAttackSpeed;
            
        }





       if( Input.GetKeyDown(KeyCode.G))
        {
            FindClosestEnemy();
            TurretShot();
           
        }
    }
    public void FindClosestEnemy()
    {
        
        Vector3 turretPosition = turret.transform.position;
        closestEnemy = Mathf.Infinity;
        Collider[] colliders = Physics.OverlapSphere(turretPosition, turretRange);

        foreach (Collider hit in colliders)
        {
            
            float distToEnemy = Vector3.Distance(hit.transform.position, turretPosition);
            Enemy enemyHit = hit.transform.GetComponent<Enemy>();

            
            if (enemyHit != null && distToEnemy < closestEnemy)
            {
                closestEnemy = distToEnemy;
                bestTarget = enemyHit.transform;
            }
        }
      
    }
    void TurretShot()
    {
        GameObject turretBulletInstance;
        turretBulletInstance = Instantiate(bullet, turretFirePoint.transform.position, Quaternion.identity);
        bulletRB = turretBulletInstance.GetComponent<Rigidbody>();
        bulletRB.transform.LookAt(bestTarget);
        bulletRB.AddForce(bulletRB.transform.forward * turretBulletSpeed, ForceMode.Impulse);

    }
}
