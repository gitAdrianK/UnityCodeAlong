using System.Collections;
using System.Collections.Generic;

class ModDoubleItem : ModChest
{
    public static string description = "Doubles the item in this chest.";

    public override void Apply(EncounterChest chest)
    {
        if (chest.Items == null)
        {
            return;
        }
        Dictionary<Item, int> dict = chest.Items;
        List<Item> items = new List<Item>(chest.Items.Keys);
        foreach (Item item in items)
        {
            dict[item] = dict[item] * 2;
        }
    }
}
