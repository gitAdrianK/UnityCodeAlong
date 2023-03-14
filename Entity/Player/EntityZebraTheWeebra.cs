using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity zebra the weebra.
/// </summary>
/// <seealso cref="EntityPlayer" />
public class EntityZebraTheWeebra : EntityPlayer
{
    public static string playerName = "Zebra The Weebra";
    public static int playerLife = 90;
    public static int playerAttack = 5;
    public static int playerDefense = 15;
    public static int playerGold = 322;
    public static Dictionary<Item, int> playerItems = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityZebraTheWeebra"/> class.
    /// </summary>
    public EntityZebraTheWeebra()
    {
        this.Initialize(playerName, playerLife, playerAttack, playerDefense, playerGold, playerItems);
    }
}
