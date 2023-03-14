using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton.
/// </summary>
/// <seealso cref="MonoBehaviour" />
public class Singleton : MonoBehaviour
{
    public static Singleton instance;

    public EntityPlayer entityPlayer;

    // Awake is called when the script instance is being loaded
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
