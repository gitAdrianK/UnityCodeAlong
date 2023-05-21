using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gigahobo.
/// </summary>
/// <seealso cref="EntityEnemy" />
public class EntityGangster : EntityEnemy
{
    public static int difficulty = 3;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityGangster"/> class.
    /// </summary>
    public EntityGangster()
    {
        base.Initialize("Gangster", 20, 4, 2);
    }

    // override object.ToString
    public override void OnDeath(EntityPlayer player)
    {

    }
}
