using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gigahobo.
/// </summary>
/// <seealso cref="EntityEnemy" />
public class EntityGigahobo : EntityEnemy
{
    public static int difficulty = 4;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityGigahobo"/> class.
    /// </summary>
    public EntityGigahobo()
    {
        base.Initialize("Gigahobo", 50, 7, 7);
    }

    // override object.ToString
    public override void OnDeath(EntityPlayer player)
    {

    }
}
