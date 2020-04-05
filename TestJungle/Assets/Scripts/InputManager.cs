using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode[] abilityKeys;
   public  List<KeyCode> abilityList = new List<KeyCode>(4);

    void Start()
    {
        abilityList.Add(KeyCode.Q);
        abilityList.Add(KeyCode.E);
        abilityList.Add(KeyCode.R);
        abilityList.Add(KeyCode.F);

        abilityKeys = new KeyCode[] { KeyCode.Q, KeyCode.E, KeyCode.R, KeyCode.F };
       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            abilityList.RemoveAt(0);
        }
    }
}
