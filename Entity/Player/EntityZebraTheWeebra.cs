using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity zebra the weebra.
/// </summary>
/// <seealso cref="EntityPlayer" />
public class EntityZebraTheWeebra : EntityPlayer
{
    private static string playerName = "Zebra The Weebra";
    private static int playerLife = 90;
    private static int playerAttack = 5;
    private static int playerDefense = 15;
    private static int playerGold = 322;
    private static Dictionary<Item, int> playerItems = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityZebraTheWeebra"/> class.
    /// </summary>
    public EntityZebraTheWeebra()
    {
        this.Initialize(playerName, playerLife, playerAttack, playerDefense, playerGold, playerItems);
    }
}
