using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item.
/// </summary>
/// <seealso cref="ScriptableObject" />
public abstract class Item : ScriptableObject
{
    /// <brief>
    /// Returns a random item.
    /// </brief>
    /// <returns>Item that was randomly generated</returns>
    public static Item getRandomItem()
    {
        switch (Random.Range(0, 2))
        {
            case 0: return (Item)ScriptableObject.CreateInstance(typeof(ItemBlacksmithsWhetstone));
            case 1: return (Item)ScriptableObject.CreateInstance(typeof(ItemArmourersScrap));
            default: return (Item)ScriptableObject.CreateInstance(typeof(ItemThePowerOfFriendship));
        }
    }

    protected new string name;
    protected string description;

    public string Name { get => name; }
    public string Description { get => description; }

    protected Item(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    /// <summary>
    /// On item gained.
    /// </summary>
    /// <param name="player">The player.</param>
    public abstract void OnItemGained(EntityPlayer player);

    /// <summary>
    /// On item lost.
    /// </summary>
    /// <param name="player">The player.</param>
    public abstract void OnItemLost(EntityPlayer player);

    public override string ToString()
    {
        return "Item - Name: " + Name;
    }
}
