using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{

    public int level = 1;
    public int exp;
   public  int expToNextLevel;

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = 100 * level;
    }

    // Update is called once per frame
    void Update()
    {
        expToNextLevel = 100 * level;
    }
    public void AddExp(int amount)
    {
        exp += amount;
        if (exp >= expToNextLevel)
        {
            level++;
            exp -= expToNextLevel;
        }
    }
}
