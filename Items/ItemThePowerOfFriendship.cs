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

    public ItemThePowerOfFriendship() : base(itemName, itemDescription)
    {

    }

    public override void OnItemGained(EntityPlayer player)
    {
        // This item does nothing.
    }

    public override void OnItemLost(EntityPlayer player)
    {
        // This item does nothing.
    }
}
