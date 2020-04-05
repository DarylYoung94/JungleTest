using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basicmovement : MonoBehaviour
{
    public float movespeed;
    public Rigidbody rigid;
    Vector3 inputVector;
    public GameObject cam;
    public float jumpForce;
    public float gravity ;
    public bool flight = true;
    public bool camYLock = false;
    public float verticalVelocity;
    public float flightGravity;
    public Vector3 lookat;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player;
        rigid = GetComponent<Rigidbody>();
        movespeed = 4f;
        jumpForce = 100f;
        camYLock = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.playerActive)
        {
            if (flight)
            {
                gravity = flightGravity *Time.deltaTime;
            }
            else
            {
                gravity = 0;
                
                if (Input.GetKeyDown(KeyCode.Space))
                {
                  
                    rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    
                }
                

            }
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                movespeed = movespeed + 4f;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                movespeed = movespeed - 4f;
            }
            transform.Rotate(new Vector3(0, 0, 0));
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * movespeed, 0, Input.GetAxisRaw("Vertical") * movespeed);
            verticalVelocity = gravity;// * Time.deltaTime;
            rigid.velocity = GetCameraTurn() * inputVector - new Vector3(0, verticalVelocity, 0);
            transform.LookAt((this.transform.position + GetCameraTurn() * inputVector));
            //lookat = player.GetComponent<BasicAttack>().basicAtkAim;
            //transform.LookAt(lookat);
        }

        else
        {
            rigid.velocity = new Vector3(0, 0, 0);
        }
    }
   
    private Quaternion GetCameraTurn()
        {
            return Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up).normalized;
        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            flight = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            flight = true;
        }
    }
    void CamLock()
    {
        
    }

}

