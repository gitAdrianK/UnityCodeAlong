using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityZebraTheWeebra : EntityPlayer
{
    private static string playerName = "Zebra The Weebra";
    private static int playerLife = 90;
    private static int playerAttack = 5;
    private static int playerDefense = 15;
    private static int playerGold = 322;
    private static Dictionary<Item, int> playerItems = null;

    public EntityZebraTheWeebra()
    {
        this.Initialize(playerName, playerLife, playerAttack, playerDefense, playerGold, playerItems);
    }
}
