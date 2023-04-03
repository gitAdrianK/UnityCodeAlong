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
    private LinkedList<Enemy> enemies;

    [SerializeField] private TMP_Text contents;

    /// <summary>
    /// Initialize.
    /// </summary>
    /// <param name="dialog">The dialog.</param>
    /// <param name="player">The player.</param>
    /// <param name="enemies">The enemies.</param>
    public void Initialize(GameObject dialog, Player player, LinkedList<Enemy> enemies)
    {
        this.dialog = dialog;
        this.player = player;
        this.enemies = enemies;
        string contents = "";
        foreach (Enemy enemy in enemies)
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
