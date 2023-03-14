using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity pepe maldini.
/// </summary>
/// <seealso cref="EntityPlayer" />
public class EntityPepeMaldini : EntityPlayer
{
    public static string playerName = "Pepe Maldini";
    public static int playerLife = 90;
    public static int playerAttack = 15;
    public static int playerDefense = 5;
    public static int playerGold = 69;
    public static Dictionary<Item, int> playerItems = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityPepeMaldini"/> class.
    /// </summary>
    public EntityPepeMaldini()
    {
        this.Initialize(playerName, playerLife, playerAttack, playerDefense, playerGold, playerItems);
    }
}
