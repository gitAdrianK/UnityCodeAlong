using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hobo.
/// </summary>
/// <seealso cref="EntityEnemy" />
public class EntityHobo : EntityEnemy
{
    public static int difficulty = 1;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityHobo"/> class.
    /// </summary>
    public EntityHobo()
    {
        base.Initialize("Hobo", 10, 3, 5);
    }

    // override object.ToString
    public override void OnDeath(EntityPlayer player)
    {

    }
}
