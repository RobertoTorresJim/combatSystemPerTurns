using UnityEngine;

public enum AttackType { Physical, Special, Status }

[System.Serializable]
public class Attack
{
    public string name;
    public AttackType type;
    public int power;
    public int effectValue;
    public PokemonType? moveType;
    public int maxPP; // Puntos de poder máximos
    public int currentPP; // Puntos de poder actuales

    public Attack(string name, AttackType type, int power, int effectValue, int maxPP, PokemonType? moveType = null)
    {
        this.name = name;
        this.type = type;
        this.power = power;
        this.effectValue = effectValue;
        this.maxPP = maxPP;
        this.currentPP = maxPP;
        this.moveType = moveType;
    }

    public bool CanUse()
    {
        return currentPP > 0;
    }

    public void UseMove()
    {
        if (currentPP > 0)
        {
            currentPP--;
        }
        else
        {
            Debug.Log($"No quedan PP para {name}!");
        }
    }
}
