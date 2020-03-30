using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharge : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private Vector3 enemyAim;
    public float timer;
    public float chargeTimer;
    public float distanceFromPlayer;
    public float chargeRange;
    public Rigidbody enemyRB;
    public float chargeSpeed;
    public float chargeDamage;
    public bool charging ;

    public float chargingTimer;
    public float timer2;

    private void Start()
    {
        chargeTimer = 5;
        enemy = this.gameObject;
        player = GameManager.instance.player;
        charging = true;
    }

    private void Update()
    {
        distanceFromPlayer = Vector3.Distance(player.transform.position, enemy.transform.position);
        timer += Time.deltaTime;
        if (timer >= chargeTimer && distanceFromPlayer <= chargeRange)
        {
            {
                Charge();
                timer = 0;
               // charging = false;
            }
        }

    }


    void Charge()
    {
        /*charging = true;
        timer2 += Time.deltaTime;
        if(timer2 >= chargingTimer)
        {
            charging = false;
        }*/
        
        enemyAim = player.transform.position;
        enemyRB = enemy.GetComponent<Rigidbody>();
        enemyRB.transform.LookAt(enemyAim);
        enemyRB.AddForce(enemyRB.transform.forward * chargeSpeed, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && charging == true)
        {
            PlayerManager playerHit = collision.transform.GetComponent<PlayerManager>();
            if (playerHit != null)
            {
                Debug.Log("take damage");
                playerHit.TakeDamage(chargeDamage);
            }
        }
    }


}
