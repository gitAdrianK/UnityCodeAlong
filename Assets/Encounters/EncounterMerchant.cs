using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Encounter merchant.
/// </summary>
/// <seealso cref="Encounter" />
public class EncounterMerchant : Encounter
{
    // The items and prices of offered items.
    LinkedList<Item> items;
    LinkedList<int> prices;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // override encounter.HandleEncounter
    public override void HandleEncounter(Player player)
    {
        // TODO: Merchant UI
        // Time.timeScale = 0.0f;

        Debug.Log("[NYI] Merchant");
    }
}
