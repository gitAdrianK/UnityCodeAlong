using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity.
/// </summary>
/// <seealso cref="ScriptableObject" />
public abstract class Entity : ScriptableObject
{
    protected new string name;
    protected int maxLife;
    protected int currentLife;
    protected int attack;
    protected int defense;

    public string Name { get => name; }
    public int MaxLife { get => maxLife; }
    public int CurrentLife { get => currentLife; }
    public int Attack { get => attack; }
    public int Defense { get => defense; }

    /// <summary>
    /// Initialize.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="life">The life.</param>
    /// <param name="attack">The attack.</param>
    /// <param name="defense">The defense.</param>
    public void Initialize(string name, int life, int attack, int defense)
    {
        this.name = name;
        this.maxLife = life;
        this.currentLife = life;
        this.attack = attack;
        this.defense = defense;
    }

    /// <summary>
    /// Changes the players max life.
    /// </summary>
    /// <param name="value">Value the life is changed by.</param>
    public void ChangeMaxLifeBy(int value)
    {
        maxLife += value;
        if (maxLife <= 0)
        {
            maxLife = 1;
        }
        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
    }

    /// <summary>
    /// Changes the players current life.
    /// </summary>
    /// <param name="value">Value the life is changed by.</param>
    public void ChangeCurrentLifeBy(int value)
    {
        currentLife += value;
    }

    /// <summary>
    /// Changes the players attack.
    /// </summary>
    /// <param name="value">Value the attack is changed by.</param>
    public void ChangeAttackBy(int value)
    {
        attack += value;
    }

    /// <summary>
    /// Changes the players defense.
    /// </summary>
    /// <param name="value">Value the defense is changed by.</param>
    public void ChangeDefenseBy(int value)
    {
        defense += value;
    }

    public override string ToString()
    {
        return "Entity - Name: " + Name + ", Maxlife: " + MaxLife + ", Currentlife: " + CurrentLife + ", Attack: " + Attack + ", Defense: " + Defense;
    }
}
