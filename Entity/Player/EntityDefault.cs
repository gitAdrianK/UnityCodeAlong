using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity default.
/// </summary>
/// <seealso cref="EntityPlayer" />
public class EntityDefault : EntityPlayer
{
    public static string playerName = "Default Player";
    public static int playerLife = 100;
    public static int playerAttack = 10;
    public static int playerDefense = 10;
    public static int playerGold = 0;
    public static Dictionary<Item, int> playerItems = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityDefault"/> class.
    /// </summary>
    public EntityDefault()
    {
        this.Initialize(playerName, playerLife, playerAttack, playerDefense, playerGold, playerItems);
    }
}
