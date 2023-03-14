using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLoad : MonoBehaviour
{
    [SerializeField] private TMP_InputField customName;
    [SerializeField] private TMP_InputField customLife;
    [SerializeField] private TMP_InputField customAttack;
    [SerializeField] private TMP_InputField customDefense;
    [SerializeField] private TMP_InputField customGold;


    /// <summary>
    /// Loads game with Pepe Maldini.
    /// </summary>
    public void LoadGameWithPepeMaldini()
    {
        EntityPlayer entityPlayer = (EntityPlayer)ScriptableObject.CreateInstance(typeof(EntityPepeMaldini));
        InstantiatePlayerIfPossible(entityPlayer);
        ChangeScene.LoadScene(ChangeScene.Scene.Game);
    }

    /// <summary>
    /// Loads game with Zebra The Weebra.
    /// </summary>
    public void LoadGameWithZebraTheWeebra()
    {
        EntityPlayer entityPlayer = (EntityPlayer)ScriptableObject.CreateInstance(typeof(EntityZebraTheWeebra));
        InstantiatePlayerIfPossible(entityPlayer);
        ChangeScene.LoadScene(ChangeScene.Scene.Game);
    }

    public void LoadGameWithCustomPlayer()
    {
        EntityPlayer entityPlayer = (EntityPlayer)ScriptableObject.CreateInstance(typeof(EntityPlayer));
        entityPlayer.Initialize(
            customName.text,
            int.Parse(customLife.text),
            int.Parse(customAttack.text),
            int.Parse(customDefense.text),
            int.Parse(customGold.text),
            null
            );
        InstantiatePlayerIfPossible(entityPlayer);
        ChangeScene.LoadScene(ChangeScene.Scene.Game);
    }

    /// <summary>
    /// Instantiates player if possible.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="life">The life.</param>
    /// <param name="attack">The attack.</param>
    /// <param name="defense">The defense.</param>
    /// <param name="gold">The gold.</param>
    /// <param name="items">The items.</param>
    private void InstantiatePlayerIfPossible(EntityPlayer entityPlayer)
    {
        Singleton instance = Singleton.instance;
        if (!instance)
        {
            return;
        }
        instance.entityPlayer = entityPlayer;
    }
}
