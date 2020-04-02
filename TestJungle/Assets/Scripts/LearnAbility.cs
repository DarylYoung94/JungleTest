using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnAbility : MonoBehaviour
{
    public GameObject trigCube;
    public GameObject player;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trigCube = GameObject.FindGameObjectWithTag("PickUp");


    }
    private void Update()
    {
        trigCube = GameObject.FindGameObjectWithTag("PickUp");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (player.GetComponent<Abilityscript>().enabled == true)
            {

                Destroy(trigCube);
            }

            else
            {
                Debug.Log("Collision");

                player.GetComponent<Abilityscript>().enabled = true;

                Destroy(this.gameObject);
            }

        }


    }
}
    

