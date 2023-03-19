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
    public GameObject fight;
    public GameObject chest;
    public GameObject merchant;

    // Active game objects. Using an object pool instead of instantiating/destroying might be nice.
    private LinkedList<GameObject> activeGameObjects;

    // Cooldowns.
    private int fightCooldown;
    private int chestCooldown;
    private int merchantCooldown;

    // Position to spawn encounters at.
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        activeGameObjects = new LinkedList<GameObject>();

        fightCooldown = Random.Range(3000, 4000);
        chestCooldown = Random.Range(0, 1000);
        merchantCooldown = Random.Range(20_000, 25_000);

        spawnPosition = new Vector3(1100, -50, 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (Singleton.instance.isPaused)
        {
            return;
        }
        if (fightCooldown < 0)
        {
            activeGameObjects.AddLast(Instantiate(fight, spawnPosition, Quaternion.identity));
            fightCooldown = Random.Range(1000, 5000);
        }
        if (chestCooldown < 0)
        {
            activeGameObjects.AddLast(Instantiate(chest, spawnPosition, Quaternion.identity));
            chestCooldown = Random.Range(1000, 5000);
        }
        if (merchantCooldown < 0)
        {
            activeGameObjects.AddLast(Instantiate(merchant, spawnPosition, Quaternion.identity));
            merchantCooldown = Random.Range(15_000, 20_000);
        }
        fightCooldown--;
        chestCooldown--;
        merchantCooldown--;
    }

    // Triggers when another collider exits the collider of this object.
    void OnTriggerExit2D(Collider2D other)
    {
        GameObject gameObject = other.gameObject;
        activeGameObjects.Remove(gameObject);
        Destroy(gameObject);
    }
}
