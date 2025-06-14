using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int armor = 2;
    [SerializeField] private int shield = 3;
    [SerializeField] private float shieldBreakChance = 0.3f;
    [SerializeField] protected Weapon activeWeapon;

    private bool shieldActive = false;
    public bool IsAlive => health > 0;

    public bool IsShieldActive()
    {
        return shieldActive;
    }

    public void SetWeapon(Weapon weapon)
    {
        activeWeapon = weapon;
    }

    public Weapon ActiveWeapon
    {
        get { return activeWeapon; }
    }
    public int GetHealth()
    {
        return health;
    }

    public void Heal(int amount)
    {
        health += amount;
        Debug.Log(name + " healed for " + amount + ", new HP: " + health);
    }

    public virtual void Attack(Character target)
    {
        if (activeWeapon == null)
        {
            Debug.LogWarning(name + " has no weapon!");
            return;
        }

        int dmg = activeWeapon.GetDamage();
        target.TakeDamage(dmg);
        activeWeapon.ApplyEffect(this, target);
    }

    public void TakeDamage(int damage)
    {
        int totalReduction = armor + (shieldActive ? shield : 0);
        int finalDamage = Mathf.Max(damage - totalReduction, 0);

        health -= finalDamage;
        Debug.Log(name + " took " + finalDamage + " damage. Remaining HP: " + health);

        if (shieldActive && Random.value < shieldBreakChance)
        {
            shieldActive = false;
            Debug.Log("Shield is broken!");
        }
    }

    public void ToggleShield()
    {
        shieldActive = !shieldActive;
        Debug.Log(name + ": Shield is now " + (shieldActive ? "ON" : "OFF"));
    }

    public void TakeDamage(Character attacker, Weapon weapon)
    {
        if (weapon == null)
        {
            Debug.LogWarning(name + " was attacked with null weapon!");
            return;
        }

        int dmg = weapon.GetDamage();
        health -= dmg;
        weapon.ApplyEffect(attacker, this); 
        Debug.Log(name + " health after hit: " + health);
    }
}
