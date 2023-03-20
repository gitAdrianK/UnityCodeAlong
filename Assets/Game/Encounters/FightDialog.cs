using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightDialog : Dialog
{
    // The enemies encountered in the fight.
    private LinkedList<Enemy> enemies;

    [SerializeField] private TMP_Text contents;

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

    public void Fight()
    {
        CloseDialog();
    }

    public void Flight()
    {
        CloseDialog();
    }
}
