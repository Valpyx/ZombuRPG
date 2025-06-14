using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private string charName;

    public string CharName
    {
        get { return charName; }
    }
    
    public override void Attack(Character target)
    {
        int dmg = activeWeapon.GetDamage();
        target.TakeDamage(dmg);
        activeWeapon.ApplyEffect(this, target);
    }
}
