using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBasicAttack : MonoBehaviour
{
    public float duration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
