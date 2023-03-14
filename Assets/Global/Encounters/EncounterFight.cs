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

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
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
    public override void HandleEncounter(EntityPlayer player)
    {
        // TODO: Fight UI
        // Time.timeScale = 0.0f;

        string log = "";
        log += "[NYI] Fight with " + enemies.Count + " enemies!\n";
        foreach (Enemy enemy in enemies)
        {
            log += enemy.Name + "\n";
        }
        Debug.Log(log);
    }
}
