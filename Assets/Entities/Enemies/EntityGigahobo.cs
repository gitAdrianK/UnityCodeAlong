using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gigahobo.
/// </summary>
/// <seealso cref="EntityEnemy" />
public class EntityGigahobo : EntityEnemy
{

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityGigahobo"/> class.
    /// </summary>
    public EntityGigahobo()
    {
        base.Initialize("Gigahobo", 50, 7, 7);
        difficulty = 4;
    }

    // override object.ToString
    public override void OnDeath(EntityPlayer player)
    {

    }
}
