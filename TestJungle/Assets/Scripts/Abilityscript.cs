using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Abilityscript : MonoBehaviour
{
    private const float T = 3f;
    Camera cam;
    //private GameObject ability1Target;
    DestroyBomb DB;

    public float radius ;
    public float power = 100f;
    public float upForce = 2f;

    public float Damage ;
    public float Speed = 10f;
    public bool activated;
   // public float range;
    public Transform Firepoint;
    public GameObject BombPrefab;
    public float nextFire;
    public float fireRate;
    public float cooldownTime = 2;
    public float nextFireTime = 0;
    public bool onCooldown;
    public LayerMask surface;
    private Vector3 mousePosition;
    Vector3 mouseToWorld;
    Vector3 mousePositionWorld;
    public Vector3 bombDirection;
    private Vector3 bombAim;
    public float distance = 100f;
    public Rigidbody bombRB;
    public GameObject Ability1TargetPrefab;
    // public GameObject ability1Target;
    public KeyCode key;

    // Start is called before the first frame update
    void Awake()
    {
        Vector3 bombDirection = -Vector3.one;
        cam = Camera.main;
        surface = LayerMask.GetMask("Terrain");
        DB = GetComponent<DestroyBomb>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
               
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast (ray, out hit))
                {
                    bombDirection = hit.point;
                }
                 
                Debug.DrawLine(bombDirection,Firepoint.position);
                Vector3 bombAim = bombDirection-Firepoint.position  ;


        if (nextFireTime > 0)
        {
            nextFireTime -= Time.deltaTime;
        }

        if (nextFireTime < 0)
        {
            nextFireTime = 0;
        }

        //instantiate target
        if (Input.GetKeyDown(key))
        {
            GameObject ability1Target;
            ability1Target = Instantiate(Ability1TargetPrefab, bombDirection, Quaternion.identity);

           
        }

         
        //Follow mouseposition
       
        

       //Shoot 
        {
            if (Input.GetKeyUp(key)  && nextFireTime == 0) //add unlocked here
            {
                ShootBomb();
                nextFireTime = cooldownTime;
                
            }
           
        }
        
        

    }
    void ShootBomb()
    {
      
        GameObject bombInstance;
        bombInstance = Instantiate(BombPrefab, Firepoint.position, Quaternion.identity) as GameObject;
        bombRB = bombInstance.GetComponent<Rigidbody>();
        bombRB.transform.LookAt(bombDirection);
        bombRB.AddForce(bombRB.transform.forward * Speed, ForceMode.Impulse); 
        
    }
    
    /*
    public void Detonate()
    {
        Vector3 explosionPosition = bombRB.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
          
            foreach(Collider hit in colliders)
        {
            Enemy enemyHit = hit.transform.GetComponent<Enemy>();
            if (enemyHit != null)
            {
                 enemyHit.damageTaken = Damage;
                enemyHit.TakeDamage(Damage);
            }
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
             rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                
            }
           
        }
        Destroy(bombRB.gameObject,0);
        
    }
    void OnCollisionEnter (Collision collision)
    {
        Enemy enemyHit = collision.transform.GetComponent<Enemy>();
        if (enemyHit != null)
        {
           // Debug.Log("Detonate");
          //  Detonate();
          //  Destroy(bombRB.gameObject,0);
            //destroy bomb to prevent double explosions
        }
       
    }

   */
}
