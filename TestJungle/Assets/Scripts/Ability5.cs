using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability5 : MonoBehaviour
{
    public KeyCode key;
    public GameObject totemPrefab;
    public float cooldownTime = 5;
    public float nextFireTime = 0;
    Camera cam;
    private Vector3 totemAimy;
    public float range;
    public float reqRange = 10;
    public GameObject player;
    public bool inRange;
    private Vector3 totemAim;
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

        range = Vector3.Distance(player.transform.position, totemAim);
        if (range <= reqRange)
        {
            inRange = true;
        }
        else
            inRange = false;



        if (Physics.Raycast(ray, out hit))
        {
            totemAim = hit.point;
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
        totemAimy = new Vector3(totemAim.x, 0, totemAim.z);
        GameObject turretInstance;
        turretInstance = Instantiate(totemPrefab, totemAim, Quaternion.identity);
        turretInstance.transform.LookAt(this.transform.position);
        Destroy(turretInstance, 5);
    }

}
