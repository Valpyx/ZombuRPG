using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Enemy
{
    [SerializeField] private int aggressionGain = 10;
    
    public override void Attack(Character target)
    {
        if (activeWeapon == null)
        {
            Debug.LogWarning(name + " has no weapon!");
            return;
        }

        int dmg = activeWeapon.GetDamage() + 5; // например, бешенство = +5 урона
        target.TakeDamage(dmg);
        activeWeapon.ApplyEffect(this, target);
    }
}
