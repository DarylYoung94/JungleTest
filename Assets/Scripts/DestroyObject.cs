using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability1Projector : MonoBehaviour
{
    Camera cam;
    public GameObject projector;
    private Vector3 bombDirection;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            bombDirection = hit.point;
        }
        if(Input.GetKey(KeyCode.Q))
        {
            bombDirection.y = 2.5f;
            transform.position = bombDirection;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Destroy(projector.gameObject);
        }
    }
}
