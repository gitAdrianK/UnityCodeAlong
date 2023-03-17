using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLoad : MonoBehaviour
{
    // The text fields presenting Pepe Maldini's Stats.
    [SerializeField] private TMP_Text pepeMaldiniName;
    [SerializeField] private TMP_Text pepeMaldiniLife;
    [SerializeField] private TMP_Text pepeMaldiniAttack;
    [SerializeField] private TMP_Text pepeMaldiniDefense;
    [SerializeField] private TMP_Text pepeMaldiniGold;

    // The text fields presenting Zebra The Weebra's Stats.
    [SerializeField] private TMP_Text zebraTheWeebraName;
    [SerializeField] private TMP_Text zebraTheWeebraLife;
    [SerializeField] private TMP_Text zebraTheWeebraAttack;
    [SerializeField] private TMP_Text zebraTheWeebraDefense;
    [SerializeField] private TMP_Text zebraTheWeebraGold;

    // The text fields presenting Custom's Stats.
    [SerializeField] private TMP_Text skillpoints;
    [SerializeField] private TMP_InputField customName;
    [SerializeField] private TMP_InputField customLife;
    [SerializeField] private TMP_InputField customAttack;
    [SerializeField] private TMP_InputField customDefense;
    [SerializeField] private TMP_InputField customGold;

    // Internal int version of customs stats to simplify skillpoint distribution and parsing.
    private int skillpointsInt;
    private int lifeInt;
    private int attackInt;
    private int defenseInt;
    private int goldInt;

    // Start is called before the first frame update
    public void Start()
    {
        pepeMaldiniName.text = EntityPepeMaldini.playerName;
        pepeMaldiniLife.text = "Life: " + EntityPepeMaldini.playerLife.ToString();
        pepeMaldiniAttack.text = "Attack: " + EntityPepeMaldini.playerAttack.ToString();
        pepeMaldiniDefense.text = "Defense: " + EntityPepeMaldini.playerDefense.ToString();
        pepeMaldiniGold.text = "Gold: " + EntityPepeMaldini.playerGold.ToString();

        zebraTheWeebraName.text = EntityZebraTheWeebra.playerName;
        zebraTheWeebraLife.text = "Life: " + EntityZebraTheWeebra.playerLife.ToString();
        zebraTheWeebraAttack.text = "Attack: " + EntityZebraTheWeebra.playerAttack.ToString();
        zebraTheWeebraDefense.text = "Defense: " + EntityZebraTheWeebra.playerDefense.ToString();
        zebraTheWeebraGold.text = "Gold: " + EntityZebraTheWeebra.playerGold.ToString();

        skillpointsInt = 15;
        lifeInt = 0;
        attackInt = 0;
        defenseInt = 0;
        goldInt = 0;

        UpdateUI();
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
        if (skillpointsInt != 0 || string.IsNullOrEmpty(customName.text))
        {
            return;
        }
        EntityPlayer entityPlayer = (EntityPlayer)ScriptableObject.CreateInstance(typeof(EntityPlayer));
        entityPlayer.Initialize(
            customName.text,
            lifeInt,
            attackInt,
            defenseInt,
            goldInt,
            null
            );
        InstantiatePlayerIfPossible(entityPlayer);
        ChangeScene.LoadScene(ChangeScene.Scene.Game);
    }

    /// <summary>
    /// Modifies life.
    /// </summary>
    /// <param name="value">The value.</param>
    public void ModifyLife(int value)
    {
        if (!CanModify(value, skillpointsInt, lifeInt))
        {
            return;
        }
        lifeInt += value;
        UpdateSkillpoints(value);
        UpdateUI();
    }

    /// <summary>
    /// Modifies attack.
    /// </summary>
    /// <param name="value">The value.</param>
    public void ModifyAttack(int value)
    {
        if (!CanModify(value, skillpointsInt, attackInt))
        {
            return;
        }
        attackInt += value;
        UpdateSkillpoints(value);
        UpdateUI();
    }

    /// <summary>
    /// Modifies defense.
    /// </summary>
    /// <param name="value">The value.</param>
    public void ModifyDefense(int value)
    {
        if (!CanModify(value, skillpointsInt, defenseInt))
        {
            return;
        }
        defenseInt += value;
        UpdateSkillpoints(value);
        UpdateUI();
    }

    /// <summary>
    /// Modifies gold.
    /// </summary>
    /// <param name="value">The value.</param>
    public void ModifyGold(int value)
    {
        if (!CanModify(value, skillpointsInt, goldInt))
        {
            return;
        }
        goldInt += value;
        UpdateSkillpoints(value);
        UpdateUI();
    }

    /// <summary>
    /// Checks if the button pressed can modify the stats.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="skillpoints">The skillpoints.</param>
    /// <param name="skillvalue">The skillvalue.</param>
    /// <returns> True if modifiable, false otherwise.</returns>
    private bool CanModify(int value, int skillpoints, int skillvalue)
    {
        if (value <= 0)
        {
            if (skillvalue <= 0)
            {
                return false;
            }
        }
        else
        {
            if (skillpoints <= 0)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Updates skillpoints.
    /// </summary>
    /// <param name="value">The value.</param>
    private void UpdateSkillpoints(int value)
    {
        if (value <= 0)
        {
            skillpointsInt++;
        }
        else
        {
            skillpointsInt--;
        }
    }

    /// <summary>
    /// Updates UI.
    /// </summary>
    private void UpdateUI()
    {
        skillpoints.text = skillpointsInt.ToString();
        customLife.text = "Life: " + lifeInt.ToString();
        customAttack.text = "Attack: " + attackInt.ToString();
        customDefense.text = "Defense: " + defenseInt.ToString();
        customGold.text = "Gold: " + goldInt.ToString();
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
