using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Encounter fight.
/// </summary>
/// <seealso cref="Encounter" />
public class EncounterFight : Encounter
{
    // Enemies that can occur
    private List<EntityEnemy> possibleEnemies;
    // The enemies encountered in the fight.
    private LinkedList<EntityEnemy> enemies;

    [SerializeField] private GameObject fightDialog;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        type = Types.Encounter.Fight;
        possibleEnemies = new List<EntityEnemy>();
        possibleEnemies.Add((EntityEnemy)ScriptableObject.CreateInstance(typeof(EntityGigahobo)));
        possibleEnemies.Add((EntityEnemy)ScriptableObject.CreateInstance(typeof(EntityGangster)));
        possibleEnemies.Add((EntityEnemy)ScriptableObject.CreateInstance(typeof(EntityThug)));
        enemies = new LinkedList<EntityEnemy>();
        BuildFightByDifficulty();
    }

    private void BuildFightByDifficulty()
    {
        int remainingDifficulty = Singleton.instance.difficulty;
        for (int i = 0; i < possibleEnemies.Count; i++)
        {
            // The current enemy cannot be added anymore w/o exceeding difficulty, skip.
            if (remainingDifficulty < possibleEnemies[i].Difficulty)
            {
                continue;
            }
            // Chance to add enemy.
            if (Random.Range(0, 4) < 2)
            {
                enemies.AddLast(Instantiate(possibleEnemies[i]));
                remainingDifficulty -= possibleEnemies[i].Difficulty;
            }
        }
        // Fill up remaing difficulty slots with hobos.
        for (; remainingDifficulty > 0; remainingDifficulty--)
        {
            enemies.AddLast((EntityEnemy)ScriptableObject.CreateInstance(typeof(EntityHobo)));
        }
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
