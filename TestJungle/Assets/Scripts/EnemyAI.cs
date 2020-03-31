using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float attackTime = 1f;
    public float nextAttackTime;
    public float attackSpeed = 1f;
    public float attackDamage = 10f;
    public float lookRadius = 10f;
    public float attackRange = 5f;
    Transform target;
    NavMeshAgent agent;
    public GameObject attackParticles;
    public bool allowAttack = true;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(AttackSpeed(attackSpeed));
        target = GameManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    IEnumerator AttackSpeed(float attackSpeed)
    {
        yield return new WaitForSeconds(attackSpeed);
        Attack1();
    }



    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }

        if (nextAttackTime > 0)
        {
            nextAttackTime -= Time.deltaTime;
        }

        if (nextAttackTime < 0)
        {
            nextAttackTime = 0;
        }
        {
            if (distance <= attackRange && nextAttackTime == 0 && allowAttack == true) 
            {
                Attack1();
                nextAttackTime = attackTime;

                GameObject particleInstance;
                particleInstance = Instantiate(attackParticles, transform.position, Quaternion.identity);

            }

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    public void Attack1()
    {
        if (target != null)
        {
              
           GameObject particleInstance;
            particleInstance = Instantiate(attackParticles, transform.position, Quaternion.identity);
            
            Vector3 attackPosition = transform.position;
            Collider[] collider = Physics.OverlapSphere(attackPosition, attackRange);

            foreach (Collider hit in collider)
            {
                PlayerManager playerHit = hit.transform.GetComponent<PlayerManager>();
                if (playerHit!= null)
                {
                    playerHit.TakeDamage(attackDamage);
                }
            }
        }
    }
}
