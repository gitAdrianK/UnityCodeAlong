using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Player.
/// </summary>
/// <seealso cref="MonoBehaviour" />
public class Player : MonoBehaviour
{
    private EntityPlayer entityPlayer;
    [SerializeField] private GameObject playerHUD;


    public void Start()
    {
        this.entityPlayer = InstantiatePlayer();
        this.InitHUD();
    }

    // Update is called once per frame
    public void Update()
    {
        // Nvm this, just putting it here for later reference.
        // if (Input.GetKeyDown("escape"))
        // {
        //     Debug.Log("Should open pausemenu");
        // }

        transform.Rotate(new Vector3(0, 0, -90 * Time.deltaTime));

        if (this.entityPlayer.CurrentLife <= 0)
        {
            ChangeScene.LoadScene(ChangeScene.Scene.GameOver);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Encounter>() is Encounter)
        {
            Encounter encounter = (Encounter)other.gameObject.GetComponent<Encounter>();
            encounter.HandleEncounter(this.entityPlayer);
            this.UpdateHUD();
        }
    }

    private EntityPlayer InstantiatePlayer()
    {
        // Allows us to start the game from a scene not containing the singleton.
        if (Singleton.instance)
        {
            Singleton instance = Singleton.instance;
            if (instance.entityPlayer)
            {
                return instance.entityPlayer;
            }
        }
        return (EntityPlayer)ScriptableObject.CreateInstance(typeof(EntityPlayer));
    }

    private void InitHUD()
    {
        PlayerHUD playerHUD = (PlayerHUD)this.playerHUD.GetComponent(typeof(PlayerHUD));
        playerHUD.InitHUD(entityPlayer);
    }

    private void UpdateHUD()
    {
        PlayerHUD playerHUD = (PlayerHUD)this.playerHUD.GetComponent(typeof(PlayerHUD));
        playerHUD.UpdateHUD(entityPlayer);
    }
}
