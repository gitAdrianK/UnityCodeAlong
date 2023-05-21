using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Spawner dialog.
/// </summary>
/// <seealso cref="Dialog" />
public class SpawnerDialog : Dialog
{
    // Slot icon
    [SerializeField] private GameObject iconSlot;

    // Encounter icons
    [SerializeField] private GameObject iconPlayer;
    [SerializeField] private GameObject iconChest;
    [SerializeField] private GameObject iconFight;
    [SerializeField] private GameObject iconMerchant;

    // The slots gameobject internal slots are attached to.
    [SerializeField] private GameObject slots;

    // The encounters gameobject internal encounters are attached to.
    [SerializeField] private GameObject icons;

    private LinkedList<Tuple<Types.Encounter, Types.ChestMod, Types.FightMod>> toSpawnEncounters;

    private BoolWrapper isCreating;

    /// <summary>
    /// Initialize.
    /// </summary>
    /// <param name="dialog">The dialog.</param>
    /// <param name="toSpawnEncounters">The to spawn encounters.</param>
    /// <param name="isCreating">The is paused.</param>
    public void Initialize(GameObject dialog, LinkedList<Tuple<Types.Encounter, Types.ChestMod, Types.FightMod>> toSpawnEncounters, BoolWrapper isCreating)
    {
        this.dialog = dialog;
        this.toSpawnEncounters = toSpawnEncounters;
        this.isCreating = isCreating;

        // Add the player icon first.
        // Create.
        GameObject playerSlot = Instantiate(iconSlot, Vector2.zero, Quaternion.identity);
        GameObject playerIcon = Instantiate(iconPlayer, Vector2.zero, Quaternion.identity);
        // Assign parent.
        playerSlot.transform.SetParent(slots.transform);
        playerIcon.transform.SetParent(icons.transform);

        int count = Singleton.instance.difficulty + 3 < 6 ? Singleton.instance.difficulty + 3 : 6;
        for (int i = 0; i < count; i++)
        {
            GameObject encounterSlot = Instantiate(iconSlot, Vector2.zero, Quaternion.identity);
            // Chest mod.
            Slot encounterSlotScript = encounterSlot.GetComponent<Slot>();
            switch (Random.Range(0, Enum.GetNames(typeof(Types.ChestMod)).Length - 1))
            {
                case 0:
                    encounterSlotScript.chestMod = Types.ChestMod.DoubleGold;
                    encounterSlotScript.SetChestDescription(ModDoubleGold.description);
                    break;
                case 1:
                    encounterSlotScript.chestMod = Types.ChestMod.DoubleItem;
                    encounterSlotScript.SetChestDescription(ModDoubleItem.description);
                    break;
            }
            // Fight mod.
            switch (Random.Range(0, Enum.GetNames(typeof(Types.FightMod)).Length - 1))
            {
                case 0:
                    encounterSlotScript.fightMod = Types.FightMod.FlatAttack;
                    encounterSlotScript.SetFightDescription(ModFlatAttack.description);
                    break;
                case 1:
                    encounterSlotScript.fightMod = Types.FightMod.FlatDefense;
                    encounterSlotScript.SetFightDescription(ModFlatDefense.description);
                    break;
                case 2:
                    encounterSlotScript.fightMod = Types.FightMod.PercentageAttack;
                    encounterSlotScript.SetFightDescription(ModPercentageAttack.description);
                    break;
                case 3:
                    encounterSlotScript.fightMod = Types.FightMod.PercentageDefense;
                    encounterSlotScript.SetFightDescription(ModPercentagedefense.description);
                    break;
            }
            GameObject encounterIcon = null;
            // Icons/Encounters.
            switch (Random.Range(0, Enum.GetNames(typeof(Types.Encounter)).Length - 1))
            {
                case 0:
                    encounterIcon = Instantiate(iconChest, Vector2.zero, Quaternion.identity);
                    break;
                case 1:
                    encounterIcon = Instantiate(iconFight, Vector2.zero, Quaternion.identity);
                    break;
                default: /* do nothing, or throw some unreachable exception */ break;
            }

            encounterSlot.transform.SetParent(slots.transform);
            encounterIcon.transform.SetParent(icons.transform);
        }

        // Add the merchant icon last.
        GameObject merchantSlot = Instantiate(iconSlot, Vector2.zero, Quaternion.identity);
        GameObject merchantIcon = Instantiate(iconMerchant, Vector2.zero, Quaternion.identity);

        merchantSlot.transform.SetParent(slots.transform);
        merchantIcon.transform.SetParent(icons.transform);

        // Move the player and merchant icons to the first and last slot and associate them with those slots.
        Canvas.ForceUpdateCanvases();
        playerIcon.transform.position = playerSlot.transform.position;
        merchantIcon.transform.position = merchantSlot.transform.position;

        Slot playerScript = playerSlot.GetComponent<Slot>();
        Slot merchantScript = merchantSlot.GetComponent<Slot>();

        playerScript.AddGameObject(playerIcon);
        merchantScript.AddGameObject(merchantIcon);

        // Remove the default mod description.
        playerScript.SetChestDescription("");
        playerScript.SetFightDescription("");

        merchantScript.SetChestDescription("");
        merchantScript.SetFightDescription("");
    }

    /// <summary>
    /// Finished.
    /// </summary>
    public void Finished()
    {
        toSpawnEncounters.Clear();
        for (int i = 1; i < slots.transform.childCount - 1; i++)
        {
            GameObject child = slots.transform.GetChild(i).gameObject;
            Slot slot = child.GetComponent<Slot>();
            if (!slot.Icon)
            {
                return;
            }
            Icon icon = slot.Icon.GetComponent<Icon>();
            if (icon.Type == Types.Encounter.Chest)
            {
                toSpawnEncounters.AddLast(Tuple.Create(Types.Encounter.Chest, slot.chestMod, slot.fightMod));
            }
            else if (icon.Type == Types.Encounter.Fight)
            {
                toSpawnEncounters.AddLast(Tuple.Create(Types.Encounter.Fight, slot.chestMod, slot.fightMod));
            }
        }
        toSpawnEncounters.AddLast(Tuple.Create(Types.Encounter.Merchant, Types.ChestMod.None, Types.FightMod.None));
        isCreating.SetFalse();
        CloseDialog();
    }
}
