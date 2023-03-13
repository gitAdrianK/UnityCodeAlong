using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Encounter chest.
/// </summary>
/// <seealso cref="Encounter" />
public class EncounterChest : Encounter
{
    // The gold the chest contains.
    private int gold;
    // The item the chest contains.
    private Item item;

    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        // Chance to be a gold chest, item chest otherwise.
        if (Random.Range(0, 11) <= 8)
        {
            gold = Random.Range(17, 43);
        }
        else
        {
            item = Item.getRandomItem();
        }
    }

    // override encounter.HandleEncounter
    public override void HandleEncounter(EntityPlayer player)
    {
        // TODO: Chest UI
        // Time.timeScale = 0.0f;

        // Adds gold or the item to the player.
        if (item)
        {
            player.AddItem(item);
        }
        else
        {
            player.ChangeGoldBy(gold);
        }
    }
}
