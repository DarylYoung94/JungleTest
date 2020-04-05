using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedBuff : MonoBehaviour
{
    public bool spawned = false;
    public GameObject player;
    public Vector3 BuffLoc;
    Camera cam;
    public GameObject buffZone;
    public float cooldownTime = 10;
    public float nextFireTime = 0;
    public float atkspeed;
    public BasicAttack basicAttack;
    public KeyCode key;
    public float buffDuration = 8;
    public float timer = 0;

    public bool triggered = false;
    public float time = 8;


    private void Start()
    {
        Vector3 BuffLoc = -Vector3.one;
        cam = Camera.main;
        
    }
    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            BuffLoc = hit.point;
        }
        if (nextFireTime > 0)
        {
            nextFireTime -= Time.deltaTime;
        }

        if (nextFireTime < 0)
        {
            nextFireTime = 0;
        }

        if (Input.GetKeyDown(key) && nextFireTime ==0)
        {
            ATKSPD();
            nextFireTime = cooldownTime;
        }




        if (triggered && !spawned )
        {
        this.gameObject.GetComponent<BasicAttack>().cooldownTime = 1f;
            triggered = false;
        }
         
        
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        spawned = false;
    }
        void ATKSPD()
    {
        spawned = true;
        GameObject buffInstance;
        buffInstance = Instantiate(buffZone, BuffLoc, Quaternion.identity);

        StartCoroutine(ExecuteAfterTime(time));

       
        Destroy(buffInstance.gameObject, 8f);
        
    }    
    
     public void OnTriggerEnter(Collider collision)
    {
        triggered = true;
       
        Debug.Log("Enter");
        if (collision.gameObject.tag == "AtkSpd")
        {
            BasicAttack PlayerInZone = collision.transform.GetComponent<BasicAttack>();
            if (player != null)
            {
                this.gameObject.GetComponent<BasicAttack>().cooldownTime = 0.5f;
            }
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        triggered = false;
        Debug.Log("Exit");
        if (collision.gameObject.tag == "AtkSpd")
        {
            BasicAttack PlayerInZone = collision.transform.GetComponent<BasicAttack>();
            if (player != null)
            {
                this.gameObject.GetComponent<BasicAttack>().cooldownTime = 1f;
            }
        }
    }




}
