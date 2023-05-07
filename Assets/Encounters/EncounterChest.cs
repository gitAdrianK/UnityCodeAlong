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
    private Dictionary<Item, int> items;

    public int Gold { get => gold; set => gold = value; }
    public Dictionary<Item, int> Items { get => items; }

    [SerializeField] private GameObject chestDialog;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        type = Types.Encounter.Chest;
        // Chance to be a gold chest, item chest otherwise.
        if (Random.Range(0, 11) <= 8)
        {
            gold = Random.Range(17, 43);
        }
        else
        {
            gold = Random.Range(8, 21);
            items.Add(Item.GetRandomItem(), 1);
        }
    }

    // override encounter.HandleEncounter
    public override void HandleEncounter(Player player)
    {
        Singleton.instance.Pause();
        GameObject obj = Instantiate(chestDialog, Vector2.zero, Quaternion.identity);
        ChestDialog script = obj.GetComponent<ChestDialog>();
        script.Initialize(obj, player, gold, items);
    }
}
