# Combat SystemPerTurns
## Paso 1: Configurar el Entorno
- Crea un nuevo proyecto de Unity (2D o 3D).
- Añade un objeto vacío llamado GameManager.
- Asigna el siguiente script al GameManager.
## Paso 2: Configurar el Inspector
- Crea dos ScriptableObjects para el jugador y el enemigo:
- Define sus estadísticas (health, defense, speed) y asigna cuatro ataques.
**Ejemplo de ataques:**
- Ataque Físico: Slash (Physical, Power: 30).
- Ataque Especial 1: Fireball (Special, Power: 40).
- Ataque Especial 2: Thunderbolt (Special, Power: 50).
- Condición: Slow Down (Status, EffectValue: 10).
## Paso 3: Interfaz del Usuario (UI)
- Crea botones para los cuatro ataques del jugador.
- Vincula los botones a la función PlayerAttack(int attackIndex) en el script CombatManager.
