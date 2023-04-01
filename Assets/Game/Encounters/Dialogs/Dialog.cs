using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dialog : MonoBehaviour
{
    protected GameObject dialog;
    protected Player player;

    protected void CloseDialog()
    {
        Singleton.instance.Resume();
        if (player)
        {
            player.UpdateHUD();
        }
        else
        {
            // Debug.Log("Player was not set! Cannot update HUD!");
        }
        if (dialog)
        {
            Destroy(dialog);
        }
        else
        {
            Debug.LogError("GameObject was not set! Cannot destroy!");
        }
    }
}
