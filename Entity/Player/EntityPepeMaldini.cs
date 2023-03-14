using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPepeMaldini : EntityPlayer
{
    private static string playerName = "Pepe Maldini";
    private static int playerLife = 90;
    private static int playerAttack = 15;
    private static int playerDefense = 5;
    private static int playerGold = 0;
    private static Dictionary<Item, int> playerItems = null;

    public EntityPepeMaldini()
    {
        this.Initialize(playerName, playerLife, playerAttack, playerDefense, playerGold, playerItems);
    }
}
