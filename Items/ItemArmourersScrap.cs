using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item armourers scrap.
/// </summary>
/// <seealso cref="Item" />
public class ItemArmourersScrap : Item
{
    private static string itemName = "Armourer's Scrap";
    private static string itemDescription = "Increases your defense power slightly!";

    public ItemArmourersScrap() : base(itemName, itemDescription)
    {

    }

    public override void OnItemGained(EntityPlayer player)
    {
        player.ChangeDefenseBy(1);
    }

    public override void OnItemLost(EntityPlayer player)
    {
        player.ChangeDefenseBy(-1);
    }
}
