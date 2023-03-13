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

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            entityPlayer = (EntityPlayer)ScriptableObject.CreateInstance(typeof(EntityPlayer));
            DontDestroyOnLoad(gameObject);
        }
    }
}
