using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gigahobo.
/// </summary>
/// <seealso cref="Enemy" />
public class Gigahobo : Enemy
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Gigahobo"/> class.
    /// </summary>
    public Gigahobo()
    {
        base.Initialize("Gigahobo", 50, 7, 7);
    }

    // override object.ToString
    public override void OnDeath(EntityPlayer player)
    {

    }
}
