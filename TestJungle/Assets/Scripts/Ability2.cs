using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability2 : MonoBehaviour
{
    public GameObject wallPrefab;
    public float cooldownTime = 5;
    public float nextFireTime = 0;
    Camera cam;
    private Vector3 wallAimy;
    public float range;
    public float reqRange = 10;
    public GameObject player;
    public bool inRange ;
    private Vector3 wallAim;
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

        range = Vector3.Distance(player.transform.position, wallAim);
        if (range <= reqRange)
        {
            inRange = true;
        }
        else
            inRange = false;



        if (Physics.Raycast(ray, out hit))
        {
            wallAim = hit.point;
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
            if (Input.GetKeyDown(KeyCode.E) && nextFireTime == 0 && inRange== true) //add unlocked here
            {
                MakeWall();
                nextFireTime = cooldownTime;
            }

        }
    }
    void SetKeyCode(KeyCode keyToSet)
    {
        keycode2 = keyToSet;
    }

    void MakeWall()
    {
        wallAimy = new Vector3(wallAim.x, 0, wallAim.z);
        GameObject wall;
        wall = Instantiate(wallPrefab, wallAim, Quaternion.identity);
        wall.transform.LookAt(this.transform.position);
        Destroy(wall, 5);
    }
}
