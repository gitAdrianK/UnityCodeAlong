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

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemBlacksmithsWhetstone"/> class.
    /// </summary>
    public ItemBlacksmithsWhetstone() : base(itemName, itemDescription)
    {

    }

    // override item.OnItemGained
    public override void OnItemGained(EntityPlayer player)
    {
        player.ChangeAttackBy(1);
    }

    // override item.OnItemLost
    public override void OnItemLost(EntityPlayer player)
    {
        player.ChangeAttackBy(-1);
    }
}
