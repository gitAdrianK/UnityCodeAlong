using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private int difficulty;
    private LinkedList<Encounter.Type> toSpawnEncounters;

    private BoolWrapper isPaused;

    public void Initialize(GameObject dialog, int difficulty, LinkedList<Encounter.Type> toSpawnEncounters, BoolWrapper isPaused)
    {
        this.dialog = dialog;
        this.difficulty = difficulty;
        this.toSpawnEncounters = toSpawnEncounters;
        this.isPaused = isPaused;

        // Add the player icon first.
        // Create.
        GameObject playerSlot = Instantiate(iconSlot, Vector2.zero, Quaternion.identity);
        GameObject playerIcon = Instantiate(iconPlayer, Vector2.zero, Quaternion.identity);
        // Assign parent.
        playerSlot.transform.SetParent(slots.transform);
        playerIcon.transform.SetParent(icons.transform);

        int count = difficulty + 3 < 6 ? difficulty + 3 : 6;
        for (int i = 0; i < count; i++)
        {
            GameObject encounterSlot = Instantiate(iconSlot, Vector2.zero, Quaternion.identity);
            GameObject encounterIcon = null;
            switch (Random.Range(0, 2))
            {
                case 0:
                    encounterIcon = Instantiate(iconChest, Vector2.zero, Quaternion.identity);
                    break;
                case 1:
                    encounterIcon = Instantiate(iconFight, Vector2.zero, Quaternion.identity);
                    break;
                default: /* do nothing, or throw some unreachble exception */ break;
            }

            encounterSlot.transform.SetParent(slots.transform);
            encounterIcon.transform.SetParent(icons.transform);
        }

        // Add the merchant icon last.
        GameObject merchantSlot = Instantiate(iconSlot, Vector2.zero, Quaternion.identity);
        GameObject merchantIcon = Instantiate(iconMerchant, Vector2.zero, Quaternion.identity);

        merchantSlot.transform.SetParent(slots.transform);
        merchantIcon.transform.SetParent(icons.transform);

        Canvas.ForceUpdateCanvases();
        playerIcon.transform.position = playerSlot.transform.position;
        merchantIcon.transform.position = merchantSlot.transform.position;

        Slot playerScript = playerSlot.GetComponent<Slot>();
        Slot merchantScript = merchantSlot.GetComponent<Slot>();

        playerScript.Icon = playerIcon;
        merchantScript.Icon = merchantIcon;
    }

    public void Finished()
    {
        toSpawnEncounters.Clear();
        for (int i = 1; i < slots.transform.childCount; i++)
        {
            Transform child = slots.transform.GetChild(i);
            Slot script = child.GetComponent<Slot>();
            if (!script.Icon)
            {
                return;
            }
            // XXX: Super shady. Don't want to use Contains!
            if (script.Icon.name.Contains("Chest"))
            {
                toSpawnEncounters.AddLast(Encounter.Type.Chest);
            }
            else if (script.Icon.name.Contains("Fight"))
            {
                toSpawnEncounters.AddLast(Encounter.Type.Fight);
            }
            else if (script.Icon.name.Contains("Merchant"))
            {
                toSpawnEncounters.AddLast(Encounter.Type.Merchant);
            }
        }
        isPaused.Value = false;
        CloseDialog();
    }
}
