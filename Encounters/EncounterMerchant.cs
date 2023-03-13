using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Encounter merchant.
/// </summary>
/// <seealso cref="Encounter" />
public class EncounterMerchant : Encounter
{
    // The items offered.
    LinkedList<Item> items;
    // The prices of the offered items.
    LinkedList<int> prices;

    public new void Start()
    {
        base.Start();
    }

    public override void HandleEncounter(EntityPlayer player)
    {
        // TODO: Merchant UI
        // Time.timeScale = 0.0f;

        Debug.Log("[NYI] Merchant");
    }
}
