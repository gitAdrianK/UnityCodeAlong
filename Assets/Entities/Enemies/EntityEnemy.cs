using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy.
/// </summary>
/// <seealso cref="Entity" />
public abstract class EntityEnemy : Entity
{
    protected int difficulty = 1;
    public int Difficulty { get => difficulty; }

    /// <summary>
    /// Actions on death.
    /// </summary>
    public abstract void OnDeath(EntityPlayer player);

    // override object.ToString
    public override string ToString()
    {
        return base.ToString() + "\nEnemy - ";
    }
}
