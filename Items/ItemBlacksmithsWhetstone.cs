using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item blacksmiths whetstone.
/// </summary>
/// <seealso cref="Item" />
public class ItemBlacksmithsWhetstone : Item
{
    private static string itemName = "Blacksmith's Whetstone";
    private static string itemDescription = "Increases your attack power slightly!";

    public ItemBlacksmithsWhetstone() : base(itemName, itemDescription)
    {

    }

    public override void OnItemGained(EntityPlayer player)
    {
        player.ChangeAttackBy(1);
    }

    public override void OnItemLost(EntityPlayer player)
    {
        player.ChangeAttackBy(-1);
    }
}
