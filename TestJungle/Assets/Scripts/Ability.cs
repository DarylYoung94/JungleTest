using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ability
{
    private string name;
    private string description;
    private Sprite icon;
    private List<AbilityBehaviours> behaviours;
    private bool requiresTarget;
    private bool canCastOnSelf;
    private int cooldown;
    private GameObject particleEffect; // needs assigned when we create ability 

    public Ability(string aname, string adescription, Sprite aicon, List<AbilityBehaviours> abehaviours)
    {
        name = aname;
        icon = aicon;
        behaviours = new List<AbilityBehaviours>();
        behaviours = abehaviours;
        cooldown = 0;
        requiresTarget = false;
        canCastOnSelf = false;
        description = "Default"; 
    }

    public Ability(string aname, string adescription, Sprite aicon, List<AbilityBehaviours> abehaviours, bool arequiresTarget)
    {
        name = aname;
        icon = aicon;
        behaviours = new List<AbilityBehaviours>();
        behaviours = abehaviours;
        cooldown = 0;
        requiresTarget = false;
        canCastOnSelf = false;
        description = "Default";
    }

    public string AbilityName
    {
        get { return name; }
    }
    public string AbilityDescription
    {
        get { return description; }
    }
    public Sprite AbilityIcon
    {
        get { return icon; }
    }
    public int AbilityCooldown
    {
        get { return cooldown; }
    }
    public List<AbilityBehaviours> AbilityBehaviours
    {
        get { return behaviours; }
    }

    public void UseAbility()
    {

    }

}
