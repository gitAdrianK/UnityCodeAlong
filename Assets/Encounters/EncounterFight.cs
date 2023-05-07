using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Encounter fight.
/// </summary>
/// <seealso cref="Encounter" />
public class EncounterFight : Encounter
{
    // The enemies encountered in the fight.
    private LinkedList<Enemy> enemies;

    [SerializeField] private GameObject fightDialog;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        type = Types.Encounter.Fight;
        enemies = new LinkedList<Enemy>();
        enemies.AddLast(GetRandomEnemy());
        for (int i = 0; i < 5; i++)
        {
            if (Random.Range(0, 100 + 1) < 25)
            {
                enemies.AddLast(GetRandomEnemy());
            }
        }
    }

    /// <summary>
    /// Gets random enemy.
    /// </summary>
    private Enemy GetRandomEnemy()
    {
        if (Random.Range(0, 100 + 1) < 10)
        {
            return (Enemy)ScriptableObject.CreateInstance(typeof(Gigahobo));
        }
        return (Enemy)ScriptableObject.CreateInstance(typeof(Hobo));
    }

    // override encounter.HandleEncounter
    public override void HandleEncounter(Player player)
    {
        Singleton.instance.Pause();
        GameObject obj = Instantiate(fightDialog, Vector2.zero, Quaternion.identity);
        EntityPlayer modPlayer;
        if (mod is ModFight)
        {
            ModFight fightMod = (ModFight)mod;
            modPlayer = fightMod.Apply(player.EntityPlayer);
        }
        else
        {
            modPlayer = player.EntityPlayer;
        }
        FightDialog script = obj.GetComponent<FightDialog>();
        script.Initialize(obj, player, enemies, modPlayer);
    }
}
