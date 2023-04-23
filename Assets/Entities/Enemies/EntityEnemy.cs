using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy.
/// </summary>
/// <seealso cref="Entity" />
public abstract class Enemy : Entity
{
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
