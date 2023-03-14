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

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemArmourersScrap"/> class.
    /// </summary>
    public ItemArmourersScrap() : base(itemName, itemDescription)
    {

    }

    // override item.OnItemGained
    public override void OnItemGained(EntityPlayer player)
    {
        player.ChangeDefenseBy(1);
    }

    // override item.OnItemLost
    public override void OnItemLost(EntityPlayer player)
    {
        player.ChangeDefenseBy(-1);
    }
}
