using UnityEngine;

public class Puble : Enemy
{
    public override void Attack(Character target)
    {
        if (activeWeapon == null)
        {
            Debug.LogWarning(name + " has no weapon!");
            return;
        }

        int totalDamage = 0;

        for (int i = 0; i < 2; i++) 
        {
            int damage = Mathf.Clamp(activeWeapon.GetDamage() - 2, 1, 999); 
            target.TakeDamage(this, activeWeapon);
            totalDamage += damage;
        }

        Debug.Log(name + " (Puble) attacks twice for total ~" + totalDamage);
    }
}