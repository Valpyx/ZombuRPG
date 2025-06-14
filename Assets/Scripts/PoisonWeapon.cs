using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonWeapon : Weapon
{
    [SerializeField] private int poisonDamage = 2;

    public override void ApplyEffect(Character attacker, Character target)
    {
        target.TakeDamage(poisonDamage);
        Debug.Log(target.name + " took " + poisonDamage + " poison damage");
    }
}
