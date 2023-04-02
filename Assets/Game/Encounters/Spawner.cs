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

    private List<GameObject> toSpawnEncounters;
    private int encounterCounter;
    private int encounterCooldown;

    // Active game objects. Using an object pool instead of instantiating/destroying might be nice.
    private LinkedList<GameObject> activeGameObjects;

    // Position to spawn encounters at.
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        toSpawnEncounters = new List<GameObject>();
        encounterCounter = 0;
        encounterCooldown = 500;

        difficulty = 0;

        activeGameObjects = new LinkedList<GameObject>();

        spawnPosition = new Vector3(1100, -50, 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (Singleton.instance.isPaused)
        {
            return;
        }
        if (toSpawnEncounters.Count >= encounterCounter)
        {
            //Singleton.instance.Pause();
            //GameObject obj = Instantiate(spawnerDialog, Vector2.zero, Quaternion.identity);
            //SpawnerDialog script = obj.GetComponent<SpawnerDialog>();
            //script.Initialize(obj, difficulty, toSpawnEncounters);
            return;
        }
        if (encounterCooldown < 0)
        {
            GameObject encounter = Instantiate(toSpawnEncounters[encounterCounter], spawnPosition, Quaternion.identity);
            activeGameObjects.AddLast(encounter);
            encounterCounter++;
            encounterCooldown = 500;
        }
        encounterCooldown--;
    }

    // Triggers when another collider exits the collider of this object.
    void OnTriggerExit2D(Collider2D other)
    {
        GameObject gameObject = other.gameObject;
        activeGameObjects.Remove(gameObject);
        Destroy(gameObject);
    }
}
