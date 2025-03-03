using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public Character player;
    public Character enemy;

    private bool playerTurn = true;

    void Start()
    {
        Debug.Log("Battle Start! Player's Turn.");
    }

    void Update()
    {
        if (playerTurn)
        {
            // Espera a que el jugador seleccione un ataque
        }
        else
        {
            EnemyTurn();
        }
    }

    public void PlayerAttack(int attackIndex)
    {
        Attack attack = player.attacks[attackIndex];
        ExecuteAttack(player, enemy, attack);

        if (enemy.health <= 0)
        {
            Debug.Log("Enemy Defeated!");
            return;
        }

        playerTurn = false;
        Debug.Log("Enemy's Turn.");
    }

    private void EnemyTurn()
    {
        // Enemigo usa un ataque aleatorio
        int randomAttack = Random.Range(0, enemy.attacks.Length);
        Attack attack = enemy.attacks[randomAttack];
        ExecuteAttack(enemy, player, attack);

        if (player.health <= 0)
        {
            Debug.Log("Player Defeated!");
            return;
        }

        playerTurn = true;
        Debug.Log("Player's Turn.");
    }

    private void ExecuteAttack(Character attacker, Character target, Attack attack)
    {
        Debug.Log($"{attacker.name} used {attack.name}!");

        if (attack.type == AttackType.Physical || attack.type == AttackType.Special)
        {
            int damage = attack.power - target.defense;
            damage = Mathf.Max(damage, 0);
            target.health -= damage;

            Debug.Log($"{target.name} took {damage} damage! Remaining HP: {target.health}");
        }
        else if (attack.type == AttackType.Status)
        {
            target.speed -= attack.effectValue;
            Debug.Log($"{target.name}'s Speed reduced by {attack.effectValue}! New Speed: {target.speed}");
        }
    }
}