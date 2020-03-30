using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    
    public float movespeed;
    public Rigidbody rigid;
    Vector3 inputVector;
    public GameObject cam;
    public float jumpForce = 200f;
    //Vector3 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        movespeed = 4f;
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * movespeed, 0, Input.GetAxisRaw("Vertical") * movespeed);


    }
    

}