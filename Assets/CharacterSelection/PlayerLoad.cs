using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLoad : MonoBehaviour
{
    [SerializeField] private TMP_Text pepeMaldiniName;
    [SerializeField] private TMP_Text pepeMaldiniLife;
    [SerializeField] private TMP_Text pepeMaldiniAttack;
    [SerializeField] private TMP_Text pepeMaldiniDefense;
    [SerializeField] private TMP_Text pepeMaldiniGold;

    [SerializeField] private TMP_Text zebraTheWeebraName;
    [SerializeField] private TMP_Text zebraTheWeebraLife;
    [SerializeField] private TMP_Text zebraTheWeebraAttack;
    [SerializeField] private TMP_Text zebraTheWeebraDefense;
    [SerializeField] private TMP_Text zebraTheWeebraGold;

    [SerializeField] private TMP_InputField customName;
    [SerializeField] private TMP_InputField customLife;
    [SerializeField] private TMP_InputField customAttack;
    [SerializeField] private TMP_InputField customDefense;
    [SerializeField] private TMP_InputField customGold;

    public void Start()
    {
        pepeMaldiniName.text = EntityPepeMaldini.playerName;
        pepeMaldiniLife.text = "Life: " + EntityPepeMaldini.playerLife.ToString();
        pepeMaldiniAttack.text = "Attack: " + EntityPepeMaldini.playerAttack.ToString();
        pepeMaldiniDefense.text = "Defense: " + EntityPepeMaldini.playerDefense.ToString();
        pepeMaldiniGold.text= "Gold: " + EntityPepeMaldini.playerGold.ToString();

        zebraTheWeebraName.text = EntityZebraTheWeebra.playerName;
        zebraTheWeebraLife.text = "Life: " + EntityZebraTheWeebra.playerLife.ToString();
        zebraTheWeebraAttack.text = "Attack: " + EntityZebraTheWeebra.playerAttack.ToString();
        zebraTheWeebraDefense.text = "Defense: " + EntityZebraTheWeebra.playerDefense.ToString();
        zebraTheWeebraGold.text= "Gold: " + EntityZebraTheWeebra.playerGold.ToString();
    }

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

    /// <summary>
    /// Loads game with custom player.
    /// </summary>
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
    /// <param name="entityPlayer">The entity player.</param>
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
