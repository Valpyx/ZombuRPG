using UnityEngine;

public class MagicWand : Weapon
{
    private int cooldown = 3;
    private int turnsRemaining = 0;
    private int healAmount = 5;

    public override void ApplyEffect(Character attacker, Character target)
    {
        if (turnsRemaining > 0)
        {
            Debug.Log("Magic Wand is recharging. " + turnsRemaining + " turns left.");
            turnsRemaining--;
            return;
        }

        attacker.Heal(healAmount);
        Debug.Log(attacker.name + " healed for " + healAmount + " using Magic Wand.");
        turnsRemaining = cooldown;
    }
}
