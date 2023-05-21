using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hobo.
/// </summary>
/// <seealso cref="EntityEnemy" />
public class EntityHobo : EntityEnemy
{

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityHobo"/> class.
    /// </summary>
    public EntityHobo()
    {
        base.Initialize("Hobo", 10, 3, 5);
        difficulty = 1;
    }

    // override object.ToString
    public override void OnDeath(EntityPlayer player)
    {

    }
}
