using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hobo.
/// </summary>
/// <seealso cref="Enemy" />
public class Hobo : Enemy
{
    public Hobo()
    {
        base.Initialize("Hobo", 10, 5, 5);
    }

    public override void OnDeath(EntityPlayer player)
    {

    }
}
