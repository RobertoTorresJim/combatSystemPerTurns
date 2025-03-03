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
        if (!attack.CanUse())
        {
            Debug.Log($"{attacker.name} no puede usar {attack.name}, se agotaron los PP!");
            return;
        }

        attack.UseMove();
        float effectiveness = TypeChart.GetEffectiveness(attack.moveType ?? PokemonType.Normal, target.primaryType);

        int damage = attack.power - target.defense;
        damage = Mathf.Max(damage, 0);
        damage = Mathf.RoundToInt(damage * effectiveness);

        target.TakeDamage(damage);

        Debug.Log($"{attacker.name} usó {attack.name}. Efectividad: {effectiveness}. Daño: {damage}. PP restantes: {attack.currentPP}");
    }

    void Start()
{
    // Movimientos
    Attack tackle = new Attack("Tackle", AttackType.Physical, 40, 0, 35, PokemonType.Normal);
    Attack ember = new Attack("Ember", AttackType.Special, 40, 0, 25, PokemonType.Fire);
    Attack growl = new Attack("Growl", AttackType.Status, 0, -10, 40);

    // Habilidad
    Ability blaze = new Ability("Blaze", "Aumenta el poder de ataques de Fuego cuando la salud es baja.");

    // Crear Pokémon
    Pokemon charmander = new Pokemon(
        "Charmander",
        PokemonType.Fire,
        5,
        39,
        52,
        60,
        43,
        50,
        65,
        blaze,
        new Attack[] { tackle, ember, growl }
    );

    charmander.GainExperience(120); // Ganar experiencia para probar el nivel
}
}