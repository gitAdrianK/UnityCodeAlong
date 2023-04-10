using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawner.
/// </summary>
/// <seealso cref="MonoBehaviour" />
public class Spawner : MonoBehaviour
{
    // Encounters.
    [SerializeField] private GameObject fight;
    [SerializeField] private GameObject chest;
    [SerializeField] private GameObject merchant;

    // The difficulty determining the amount of encounters between each merchant encounter.
    private int difficulty;

    // Spawner dialog to choose a list of encounters and to spawn once chosen.
    [SerializeField] private GameObject spawnerDialog;
    private BoolWrapper isCreating;

    private LinkedList<Types.Encounter> toSpawnEncounters;
    private int encounterCooldown;

    // Active game objects. Using an object pool instead of instantiating/destroying might be nice.
    private LinkedList<GameObject> activeGameObjects;

    // Position to spawn encounters at.
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        toSpawnEncounters = new LinkedList<Types.Encounter>();
        encounterCooldown = 500;

        difficulty = 0;

        activeGameObjects = new LinkedList<GameObject>();
        isCreating = new BoolWrapper(false);

        spawnPosition = new Vector3(1100, -50, 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (Singleton.instance.isPaused || isCreating)
        {
            return;
        }
        if (toSpawnEncounters.Count == 0 && activeGameObjects.Count == 0)
        {
            encounterCooldown = 500;
            isCreating.SetTrue();
            GameObject obj = Instantiate(spawnerDialog, Vector2.zero, Quaternion.identity);
            SpawnerDialog script = obj.GetComponent<SpawnerDialog>();
            script.Initialize(obj, difficulty, toSpawnEncounters, isCreating);
            difficulty++;
            return;
        }
        if (toSpawnEncounters.Count != 0 && encounterCooldown < 0)
        {
            GameObject encounter = Instantiate(
                CreateGameObjectFromEncounterEnum(toSpawnEncounters.First.Value),
                spawnPosition,
                Quaternion.identity
                );
            toSpawnEncounters.RemoveFirst();
            activeGameObjects.AddLast(encounter);
            encounterCooldown = 2000;
        }
        encounterCooldown--;
    }

    // Triggers when another collider exits the collider of this object.
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag != "Encounter")
        {
            return;
        }
        GameObject gameObject = other.gameObject;
        activeGameObjects.Remove(gameObject);
        Destroy(gameObject);
    }

    /// <summary>
    /// Creates game object from encounter enum.
    /// </summary>
    /// <param name="encounter">The encounter.</param>
    GameObject CreateGameObjectFromEncounterEnum(Types.Encounter encounter)
    {
        switch (encounter)
        {
            case Types.Encounter.Fight:
                return fight;
            case Types.Encounter.Chest:
                return chest;
            case Types.Encounter.Merchant:
                return merchant;
            default:
                return null;
        }
    }
}
