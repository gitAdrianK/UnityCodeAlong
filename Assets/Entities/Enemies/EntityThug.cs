using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gigahobo.
/// </summary>
/// <seealso cref="EntityEnemy" />
public class EntityThug : EntityEnemy
{

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityThug"/> class.
    /// </summary>
    public EntityThug()
    {
        base.Initialize("Thug", 15, 7, 5);
        difficulty = 2;
    }

    // override object.ToString
    public override void OnDeath(EntityPlayer player)
    {

    }
}
