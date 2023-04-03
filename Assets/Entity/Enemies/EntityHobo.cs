using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hobo.
/// </summary>
/// <seealso cref="Enemy" />
public class Hobo : Enemy
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Hobo"/> class.
    /// </summary>
    public Hobo()
    {
        base.Initialize("Hobo", 10, 5, 5);
    }

    // override object.ToString
    public override void OnDeath(EntityPlayer player)
    {

    }
}
