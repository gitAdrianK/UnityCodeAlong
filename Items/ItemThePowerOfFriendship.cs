using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item the power of friendship.
/// </summary>
/// <seealso cref="Item" />
public class ItemThePowerOfFriendship : Item
{
    private static string itemName = "The Power Of Friendship";
    private static string itemDescription = "It does nothing you dirty weeb!";

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemThePowerOfFriendship"/> class.
    /// </summary>
    public ItemThePowerOfFriendship() : base(itemName, itemDescription)
    {

    }

    // override item.OnItemGained
    public override void OnItemGained(EntityPlayer player)
    {
        // This item does nothing.
    }

    // override item.OnItemLost
    public override void OnItemLost(EntityPlayer player)
    {
        // This item does nothing.
    }
}
