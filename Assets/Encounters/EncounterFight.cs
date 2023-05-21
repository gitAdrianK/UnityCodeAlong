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
    private LinkedList<EntityEnemy> enemies;

    [SerializeField] private GameObject fightDialog;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        type = Types.Encounter.Fight;
        enemies = BuildFightByDifficulty();
    }

    private LinkedList<EntityEnemy> BuildFightByDifficulty()
    {
        int remainingDifficulty = Singleton.instance.difficulty;
        LinkedList<EntityEnemy> enemies = new LinkedList<EntityEnemy>();
        //TODO: Select enemies based on difficulty.
        // Fill up remaing difficulty slots with hobos.
        for (; remainingDifficulty > 0; remainingDifficulty--)
        {
            enemies.AddLast((EntityEnemy)ScriptableObject.CreateInstance(typeof(EntityHobo)));
        }
        return enemies;
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
