using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDamagePopUp : MonoBehaviour
{
    public float duration;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Destroy(this.gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
