using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity player.
/// </summary>
/// <seealso cref="Entity" />
public class EntityPlayer : Entity
{
    private int gold;
    private Dictionary<string, int> items;

    public int Gold { get => gold; }
    public Dictionary<string, int> Items { get => items; }

    public EntityPlayer()
    {
        this.Initialize("Default Player", 100, 10, 10, 0, null);
    }

    public void Initialize(string name, int life, int attack, int defense, int gold, Dictionary<string, int> items)
    {
        base.Initialize(name, life, attack, defense);
        this.gold = gold;
        if (items == null)
        {
            items = new Dictionary<string, int>();
        }
        this.items = items;
    }

    /// <summary>
    /// Changes the players gold.
    /// </summary>
    /// <param name="value">Value the gold is changed by.</param>
    public void ChangeGoldBy(int value)
    {
        gold += value;
        if (gold < 0)
        {
            gold = 0;
        }
    }

    /// <summary>
    /// Adds an item to the players items and modifies the player based on its gain effect.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void AddItem(Item item)
    {
        if (item == null)
        {
            return;
        }
        string name = item.Name;
        if (!items.ContainsKey(name))
        {
            items.Add(name, 0);
        }
        items[name] = ++items[name];
        item.OnItemGained(this);
    }

    /// <summary>
    /// Removes an item from the players items and modifies the player based on its loss effect.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    public void RemoveItem(Item item)
    {
        if (item == null)
        {
            return;
        }
        string name = item.Name;
        if (!items.ContainsKey(name))
        {
            return;
        }
        items[name] = --items[name];
        if (items[name] <= 0)
        {
            items.Remove(name);
        }
        item.OnItemLost(this);
    }

    public override string ToString()
    {
        string str = "";
        str += base.ToString() + "\nPlayer - Gold: " + Gold + ", Items:\n";
        foreach (KeyValuePair<string, int> kvp in items)
        {
            str += kvp.Key + ": " + kvp.Value + "\n";
        }
        return str;
    }
}
