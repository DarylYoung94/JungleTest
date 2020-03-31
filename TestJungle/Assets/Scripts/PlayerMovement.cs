using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float verticalVelocity;
    private float jumpForce = 200f;
    private float gravity = 2f;
    public float movespeed;
    public Rigidbody rigid;
    Vector3 inputVector;
    public GameObject cam;
    public bool flight = true;



    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
         movespeed = 4f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.playerActive)
        {
            if (flight)
            {
                gravity = 9f;
            }
            else
            {
                gravity = 0;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
            }
            transform.Rotate(new Vector3(0, 0, 0));
            inputVector = new Vector3(Input.GetAxis("Horizontal") * movespeed, 0, Input.GetAxis("Vertical") * movespeed);
            transform.LookAt(this.transform.position + GetCameraTurn() * inputVector);
            rigid.velocity = GetCameraTurn() * inputVector - new Vector3(0, gravity, 0);
        }
        else
        {
            rigid.velocity = new Vector3(0, 0, 0);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            flight = false;
        }

        //Debug.Log("ENTER " + collision.gameObject + " " + collision.gameObject.layer);
        //Debug.Log("FLIGHT = " + flight);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            flight = true;
        }
        //Debug.Log("EXIT " + collision.gameObject + " " + collision.gameObject.layer);
        //Debug.Log("FLIGHT = " + flight);
    }

    private Quaternion GetCameraTurn()
    {
        return Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up).normalized;
    }

}

