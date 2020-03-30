using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public GameObject basicBulletPrefab;
    private GameObject basicShot;
    public GameObject basicBullet;
  
    public float damage = 5f;
    public float range;
    public float cooldownTime ;
    public float nextFireTime = 0;
    public GameObject firePoint;
    public Vector3 basicAtkAim;
    public float bulletSpeed ;
    public Rigidbody bulletRB;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 basicAtkAim = -Vector3.one;
        cam = Camera.main;
        cooldownTime = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            basicAtkAim = hit.point;
        }

        if (nextFireTime > 0)
        {
            nextFireTime -= Time.deltaTime;
        }

        if (nextFireTime < 0)
        {
            nextFireTime = 0;
        }

        if (Input.GetMouseButton(0) && nextFireTime == 0)
        {
            RBShoot();
            //Shoot();
            nextFireTime = cooldownTime;
           
        }
        //basicBullet.transform.Translate(Vector3.forward* bulletSpeed*Time.deltaTime);
    }
    void Shoot()
    {
        basicShot = Instantiate(basicBullet, firePoint.transform.position, Quaternion.identity) as GameObject;
        basicShot.transform.LookAt(basicAtkAim);
        
        RaycastHit hit;
        if (Physics.Raycast(firePoint.transform.position, (basicAtkAim -firePoint.transform.position ), out hit, range))
        {

            Enemy enemyHit = hit.transform.GetComponent<Enemy>();
            if (enemyHit != null)
            {
                enemyHit.TakeDamage(damage);
                Debug.Log("enemy hit");
            }

        }
    }
    void RBShoot()
    {
        GameObject basicBulletInstance;
        basicBulletInstance = Instantiate(basicBulletPrefab, firePoint.transform.position, Quaternion.identity);
        bulletRB = basicBulletInstance.GetComponent<Rigidbody>();
        bulletRB.transform.LookAt(basicAtkAim);
        bulletRB.AddForce(bulletRB.transform.forward * bulletSpeed, ForceMode.Impulse);

    }
        
}
