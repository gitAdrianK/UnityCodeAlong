using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// PlayerHUD.
/// </summary>
/// <seealso cref="MonoBehaviour" />
public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text playerLife;
    [SerializeField] private TMP_Text playerAttack;
    [SerializeField] private TMP_Text playerDefense;
    [SerializeField] private TMP_Text playerGold;

    /// <summary>
    /// Inits HUD.
    /// </summary>
    /// <param name="entityPlayer">The entity player.</param>
    public void InitHUD(EntityPlayer entityPlayer)
    {
        this.playerName.text = "Name: " + entityPlayer.Name;
        UpdateHUD(entityPlayer);
    }

    /// <summary>
    /// Updates HUD.
    /// </summary>
    /// <param name="entityPlayer">The entity player.</param>
    public void UpdateHUD(EntityPlayer entityPlayer)
    {
        this.playerLife.text = "Life: " + entityPlayer.CurrentLife + "/" + entityPlayer.MaxLife;
        this.playerAttack.text = "Attack: " + entityPlayer.Attack;
        this.playerDefense.text = "Defense: " + entityPlayer.Defense;
        this.playerGold.text = "Gold: " + entityPlayer.Gold;
    }
}
