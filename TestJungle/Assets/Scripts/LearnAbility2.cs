using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnAbility2 : MonoBehaviour
{
    public GameObject trigCube;
    public GameObject player;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trigCube = GameObject.FindGameObjectWithTag("PickUp");
        // player.GetComponent<Abilityscript>().enabled = false;
        // player.GetComponent<Ability2>().enabled = false;

    }
    private void Update()
    {
        trigCube = GameObject.FindGameObjectWithTag("PickUp");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (player.GetComponent<Ability2>().enabled == true)
            {

                Destroy(trigCube);
            }

            else
                Debug.Log("Collision");
            //trigCube.SetActive(true);
            player.GetComponent<Ability2>().enabled = true;
            Destroy(trigCube);
        }

    }

}
