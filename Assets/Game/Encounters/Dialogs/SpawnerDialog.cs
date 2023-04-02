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
    // A list containing those slots for easier access than getting the gameobjects children.
    private List<GameObject> slotsList;

    // The encounters gameobject internal encounters are attached to.
    [SerializeField] private GameObject encounters;
    // A list containing those encounters for easier access than getting the gameobjects children.
    private List<GameObject> encountersList;

    private int difficulty;
    private List<GameObject> toSpawnEncounters;

    public void Start()
    {
        slotsList = new List<GameObject>();
        encountersList = new List<GameObject>();
    }

    public void Initialize(GameObject dialog, int difficulty, List<GameObject> toSpawnEncounters)
    {
        this.dialog = dialog;
        this.difficulty = difficulty;
        this.toSpawnEncounters = toSpawnEncounters;

        // TODO: Instantiate slots and encounters.

        // Add the player icon first.
        // TODO: Instantiate the player icon. Do we need this? Can we do it in the editor?
        // child.transform.parent = slots.transform;
        // this.slotsList.Add();

        int count = difficulty + 3 < 6 ? difficulty + 3 : 6;
        for (int i = 0; i < count; i++)
        {
            // TODO: Create a slot and an encounter gameobject.

            // slot.transform.parent = slots.transform;
            // this.slotsList.Add(slot);

            // encounter.transform.parent = encounters.transform;
            // this.encountersList.Add(encounter);

            Debug.Log("Element added here");
        }

        // Add the merchant icon last.
        // TODO: Instantiate the merchant icon. Do we need this? Can we do it in the editor?
        // child.transform.parent = slots.transform;
        // this.slotsList.Add();
    }

    public void Finished()
    {
        foreach (GameObject obj in slotsList)
        {
            // TODO: Fill list with encounters.
            Debug.Log("Contained encounter");
        }
        CloseDialog();
    }
}
