using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Encounter.
/// </summary>
/// <seealso cref="MonoBehaviour" />
public abstract class Encounter : MonoBehaviour
{
    // The movespeed. How quickly the encounter moves across the screen.
    private float movespeed;

    // Start is called before the first frame update
    public void Start()
    {
        this.movespeed = 5f;
    }

    // Update is called once per frame
    public void Update()
    {
        transform.Translate(Vector2.left * movespeed * Time.deltaTime);
    }

    /// <summary>
    /// Handles the encounter with a player.
    /// </summary>
    /// <param name="player">The player having the encounter.</param>
    public abstract void HandleEncounter(EntityPlayer player);
}
