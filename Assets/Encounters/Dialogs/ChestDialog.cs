using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Chest dialog.
/// </summary>
/// <seealso cref="Dialog" />
public class ChestDialog : Dialog
{
    private int gold;
    private Dictionary<Item, int> items;

    [SerializeField] private TMP_Text contents;

    /// <summary>
    /// Initialize.
    /// </summary>
    /// <param name="dialog">The dialog.</param>
    /// <param name="player">The player.</param>
    /// <param name="gold">The gold.</param>
    /// <param name="items">The items.</param>
    public void Initialize(GameObject dialog, Player player, int gold, Dictionary<Item, int> items)
    {
        this.dialog = dialog;
        this.player = player;
        this.gold = gold;
        this.items = items;
        string contents = "";
        contents += "The chest contains " + gold + " gold and ";
        if (items != null)
        {
            foreach (KeyValuePair<Item, int> item in items)
            {
                contents += "\n" + item.Key.Name + " x" + item.Value + ".";
            }
        }
        else
        {
            contents += "no item.";
        }
        this.contents.text = contents;
    }

    /// <summary>
    /// Take.
    /// </summary>
    public void Take()
    {
        EntityPlayer entityPlayer = player.EntityPlayer;
        entityPlayer.ChangeGoldBy(gold);
        entityPlayer.AddItems(items);
        CloseDialog();
    }

    /// <summary>
    /// Leave.
    /// </summary>
    public void Leave()
    {
        CloseDialog();
    }
}
