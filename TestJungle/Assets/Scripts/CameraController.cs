using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour
{

    public Transform target;

    public Vector3 offset ;
    public float pitch;
    public bool lookAtPlayer = false;
    public bool rotateAroundPlayer = true;
    public float rotationSpeed = 5.0f;
    public float smoothing = 1f;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 desiredPosition = target.position - offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothing *Time.deltaTime );
        // transform.position = smoothedPosition;
        transform.position = desiredPosition;
        transform.LookAt(target.position + Vector3.up * 2f * pitch);
        transform.position = new Vector3(desiredPosition.x, 10, desiredPosition.z);
        if (Input.GetMouseButton(1))
        {
            if (rotateAroundPlayer)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
                transform.position = new Vector3(desiredPosition.x, 10, desiredPosition.z);
                offset = camTurnAngle * offset;
            }

            if (lookAtPlayer || rotateAroundPlayer)

            {
                Vector3 targetGround = new Vector3(target.position.x, 0, target.position.z);  
                transform.position = new Vector3(desiredPosition.x, 10, desiredPosition.z);
                transform.LookAt(targetGround);
            }

        }
    }
}
