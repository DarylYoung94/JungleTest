using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static List<GameObject> AbilityTriggers = new List<GameObject>();
    private GameObject loot;
    private Vector3 spawnPoint;
    public int itemIndex;
 
    void Start()
    {
        AbilityTriggers = new List<GameObject>(Resources.LoadAll<GameObject>("Prefab"));

        Debug.Log(AbilityTriggers.Count);
    }
    
}
 