using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Encounter.
/// </summary>
/// <seealso cref="MonoBehaviour" />
public abstract class Encounter : MonoBehaviour
{
    // The type of the encounter.
    protected Types.Encounter type;
    public Types.Encounter Type { get => type; }

    // The movespeed. How quickly the encounter moves across the screen.
    private float movespeed;

    // The mod associated with this encounter.
    public Mod mod;

    // Start is called before the first frame update
    public virtual void Start()
    {
        this.type = Types.Encounter.Default;
        this.movespeed = 250f;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.Translate(Vector2.left * movespeed * Time.deltaTime);
    }

    /// <summary>
    /// Handles the encounter with a player.
    /// </summary>
    /// <param name="player">The player having the encounter.</param>
    public abstract void HandleEncounter(Player player);
}
