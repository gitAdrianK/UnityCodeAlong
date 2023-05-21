using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gigahobo.
/// </summary>
/// <seealso cref="EntityEnemy" />
public class EntityThug : EntityEnemy
{
    public static int difficulty = 2;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityThug"/> class.
    /// </summary>
    public EntityThug()
    {
        base.Initialize("Thug", 15, 7, 5);
    }

    // override object.ToString
    public override void OnDeath(EntityPlayer player)
    {

    }
}
