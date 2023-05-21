using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Fight dialog.
/// </summary>
/// <seealso cref="Dialog" />
public class FightDialog : Dialog
{
    // The enemies encountered in the fight.
    private LinkedList<EntityEnemy> enemies;
    // The player that has had slot mods applied.
    private EntityPlayer modPlayer;

    [SerializeField] private TMP_Text contents;

    /// <summary>
    /// Initialize.
    /// </summary>
    /// <param name="dialog">The dialog.</param>
    /// <param name="player">The player.</param>
    /// <param name="enemies">The enemies.</param>
    public void Initialize(GameObject dialog, Player player, LinkedList<EntityEnemy> enemies, EntityPlayer modPlayer)
    {
        this.dialog = dialog;
        this.player = player;
        this.enemies = enemies;
        this.modPlayer = modPlayer;
        string contents = "";
        foreach (EntityEnemy enemy in enemies)
        {
            contents += enemy.Name + "\n";
        }
        this.contents.text = contents;
    }

    /// <summary>
    /// Fight.
    /// </summary>
    public void Fight()
    {
        CloseDialog();
    }

    /// <summary>
    /// Flight.
    /// </summary>
    public void Flight()
    {
        CloseDialog();
    }
}
