using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability4 : MonoBehaviour
{
    public KeyCode key;
    public GameObject turretPrefab;
    public float cooldownTime = 5;
    public float nextFireTime = 0;
    Camera cam;
    private Vector3 turretAimy;
    public float range;
    public float reqRange = 10;
    public GameObject player;
    public bool inRange;
    private Vector3 turretAim;
    public KeyCode keycode2;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        player = this.gameObject;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        range = Vector3.Distance(player.transform.position, turretAim);
        if (range <= reqRange)
        {
            inRange = true;
        }
        else
            inRange = false;



        if (Physics.Raycast(ray, out hit))
        {
            turretAim = hit.point;
        }

        if (nextFireTime > 0)
        {
            nextFireTime -= Time.deltaTime;
        }

        if (nextFireTime < 0)
        {
            nextFireTime = 0;
        }
        {
            if (Input.GetKeyDown(key) && nextFireTime == 0 && inRange == true) //add unlocked here
            {
                SpawnTurret();
                nextFireTime = cooldownTime;
            }

        }
    }
    void SpawnTurret()
    {
        turretAimy = new Vector3(turretAim.x, 0, turretAim.z);
        GameObject turretInstance;
        turretInstance = Instantiate(turretPrefab, turretAim, Quaternion.identity);
        turretInstance.transform.LookAt(this.transform.position);
        Destroy(turretInstance, 5);
    }

}
