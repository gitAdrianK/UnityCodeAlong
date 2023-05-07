using System.Collections;
using System.Collections.Generic;

class ModDoubleItem : ModChest
{
    public static string description = "Doubles the item in this chest.";

    public override void Apply(EncounterChest chest)
    {
        Dictionary<Item, int> items = chest.Items;
        foreach (KeyValuePair<Item, int> item in items)
        {
            items[item.Key] = item.Value * 2;
        }
    }
}
