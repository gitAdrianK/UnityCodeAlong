using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gigahobo.
/// </summary>
/// <seealso cref="EntityEnemy" />
public class EntityGangster : EntityEnemy
{

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityGangster"/> class.
    /// </summary>
    public EntityGangster()
    {
        base.Initialize("Gangster", 20, 4, 2);
        difficulty = 3;
    }

    // override object.ToString
    public override void OnDeath(EntityPlayer player)
    {

    }
}
