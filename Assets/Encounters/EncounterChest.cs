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

    [SerializeField] private GameObject chestDialog;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        // Chance to be a gold chest, item chest otherwise.
        if (Random.Range(0, 11) <= 8)
        {
            gold = Random.Range(17, 43);
        }
        else
        {
            item = Item.GetRandomItem();
        }
    }

    // override encounter.HandleEncounter
    public override void HandleEncounter(Player player)
    {
        Singleton.instance.Pause();
        GameObject obj = Instantiate(chestDialog, Vector2.zero, Quaternion.identity);
        ChestDialog script = obj.GetComponent<ChestDialog>();
        script.Initialize(obj, player, gold, item);
    }
}
