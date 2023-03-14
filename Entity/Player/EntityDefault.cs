using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity default.
/// </summary>
/// <seealso cref="EntityPlayer" />
public class EntityDefault : EntityPlayer
{
    private static string playerName = "Default Player";
    private static int playerLife = 100;
    private static int playerAttack = 10;
    private static int playerDefense = 10;
    private static int playerGold = 0;
    private static Dictionary<Item, int> playerItems = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityDefault"/> class.
    /// </summary>
    public EntityDefault()
    {
        this.Initialize(playerName, playerLife, playerAttack, playerDefense, playerGold, playerItems);
    }
}
