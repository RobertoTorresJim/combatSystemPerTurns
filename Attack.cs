using UnityEngine;

public enum AttackType { Physical, Special, Status }

[System.Serializable]
public class Attack
{
    public string name;
    public AttackType type;
    public int power; // Solo para ataques de daño
    public int effectValue; // Solo para efectos de estado
}