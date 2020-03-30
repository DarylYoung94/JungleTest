using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyBulletPrefab;
    public GameObject enemy;
    public Transform firePoint;
    public Rigidbody bulletRB;
    public Vector3 enemyAim;
    public float bulletSpeed;
    public float timer = 0;
    public float shootTimer;
    public float distanceFromPlayer;
    public float attackRange;

    private void Start()
    {
        shootTimer = Random.Range(2, 5);
        enemy = this.gameObject;
        player = GameManager.instance.player;
    }

    private void Update()
    {
        distanceFromPlayer = Vector3.Distance(player.transform.position, enemy.transform.position);

        timer += Time.deltaTime;
        if (timer >= shootTimer && distanceFromPlayer <= attackRange)
        {
            ShootAtPlayer();
            timer = 0;
        }
    }
    void ShootAtPlayer()
    {

        enemyAim = player.transform.position;
        GameObject enemyBulletInstance;
        enemyBulletInstance = Instantiate(enemyBulletPrefab, firePoint.transform.position, Quaternion.identity);
        bulletRB = enemyBulletInstance.GetComponent<Rigidbody>();
        bulletRB.transform.LookAt(enemyAim);
        bulletRB.AddForce(bulletRB.transform.forward * bulletSpeed, ForceMode.Impulse);
    }
}
