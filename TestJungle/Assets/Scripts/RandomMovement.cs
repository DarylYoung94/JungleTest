using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public float timerForNewpath;
    bool inCoroutine = false;
    Vector3 target;
    NavMeshPath path;

    public GameObject campLocation;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    void Update()
    {
        if (!inCoroutine)
            StartCoroutine(DoSomething());
    }

    Vector3 getRandomPosition()
    {

        float x = Random.Range(-10, 10);
        float z = Random.Range(-10, 10);
        Vector3 pos = new Vector3(campLocation.transform.position.x + x, 0, campLocation.transform.position.z + z);
        return pos;
    }

    IEnumerator DoSomething()
    {
        inCoroutine = true;
        yield return new WaitForSeconds(timerForNewpath);
        GetNewPath();
        if (navMeshAgent.CalculatePath(target, path)) //Debug.Log("found invalid path");
        inCoroutine = false;
    }

    void GetNewPath()
    {
        target = getRandomPosition();
        navMeshAgent.SetDestination(target);
    }
}
