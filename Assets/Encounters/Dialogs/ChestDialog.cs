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
    private Item item;

    [SerializeField] private TMP_Text contents;

    /// <summary>
    /// Initialize.
    /// </summary>
    /// <param name="dialog">The dialog.</param>
    /// <param name="player">The player.</param>
    /// <param name="gold">The gold.</param>
    /// <param name="item">The item.</param>
    public void Initialize(GameObject dialog, Player player, int gold, Item item)
    {
        this.dialog = dialog;
        this.player = player;
        this.gold = gold;
        this.item = item;
        string contents = "";
        contents += "The chest contains " + gold + " gold and ";
        if (item)
        {
            contents += "\n" + item.Name + ".";
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
        entityPlayer.AddItem(item);
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
