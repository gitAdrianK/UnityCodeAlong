using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gigahobo.
/// </summary>
/// <seealso cref="Enemy" />
public class Gigahobo : Enemy
{
    public Gigahobo()
    {
        base.Initialize("Gigahobo", 50, 7, 7);
    }

    public override void OnDeath(EntityPlayer player)
    {

    }
}
