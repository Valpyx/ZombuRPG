using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private TMP_Text shieldStatusText;
    [SerializeField] private Weapon basicWeaponObject;
    [SerializeField] private Weapon poisonWeaponObject;
    [SerializeField] private Weapon magicWandObject;
    [SerializeField]
    private TMP_Text playerName, playerHealth,
        enemyName, enemyHealth;
    private Enemy currentEnemyInstance;

    // Start is called before the first frame update
    void Start()
    {
        player.SetWeapon(basicWeaponObject);
        SpawnNewEnemy();
        RefreshUI();
    }

    private void SpawnNewEnemy()
    {
        if (currentEnemyInstance != null)
        Destroy(currentEnemyInstance.gameObject);

        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject newEnemy = Instantiate(enemyPrefabs[index]);

        currentEnemyInstance = newEnemy.GetComponent<Enemy>();
        enemy = currentEnemyInstance;

        enemy.SetWeapon(basicWeaponObject); 
    }

    public void DoRound()
    {
        if (!player.IsAlive)
        {
            Debug.Log("Game Over");
            return;
        }

        enemy.TakeDamage(player, player.ActiveWeapon);

        if (!enemy.IsAlive)
        {
            Debug.Log("Enemy defeated!");
            SpawnNewEnemy();
            RefreshUI();
            return;
        }

        enemy.Attack(player);

        if (!player.IsAlive)
        {
            Debug.Log("Game Over");
        }

    RefreshUI();
}

    private void RefreshUI()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.name;
        playerHealth.text = "health: " + player.GetHealth().ToString();
        enemyHealth.text = "health: " + enemy.GetHealth().ToString();
        shieldStatusText.text = "Shield: " + (player.IsShieldActive() ? "ON" : "OFF");
    }

    public void TogglePlayerShield()
    {
        player.ToggleShield();
        RefreshUI();
    }

    public void SetWeapon(string type)
    {
        if (player == null) return;

        switch (type)
        {
            case "basic":
                player.SetWeapon(new BasicWeapons());
                break;
            case "poison":
                player.SetWeapon(new PoisonWeapon());
                break;
            case "magic":
                player.SetWeapon(new MagicWand());
                break;
        }

        RefreshUI();
    }

    public void UseBasicWeapon()
    {
        player.SetWeapon(basicWeaponObject);
        Debug.Log("Switched to: Basic Weapon");
    }

    public void UsePoisonWeapon()
    {
        player.SetWeapon(poisonWeaponObject);
        Debug.Log("Switched to: Poison Weapon");
    }

    public void UseMagicWand()
    {
        player.SetWeapon(magicWandObject);
        Debug.Log("Switched to: Magic Wand");
    }
}
