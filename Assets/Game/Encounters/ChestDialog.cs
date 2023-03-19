using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestDialog : MonoBehaviour
{
    private GameObject dialog;
    private Player player;
    private int gold;
    private Item item;

    [SerializeField] private TMP_Text contents;

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

    public void Take()
    {
        EntityPlayer entityPlayer = player.EntityPlayer;
        entityPlayer.ChangeGoldBy(gold);
        entityPlayer.AddItem(item);
        CloseDialog();
    }

    public void Leave()
    {
        CloseDialog();
    }

    private void CloseDialog()
    {
        player.UpdateHUD();
        Singleton.instance.Resume();
        Destroy(dialog);
    }
}
