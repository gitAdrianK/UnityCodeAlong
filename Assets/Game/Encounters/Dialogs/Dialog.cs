using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dialog.
/// </summary>
/// <seealso cref="MonoBehaviour" />
public abstract class Dialog : MonoBehaviour
{
    protected GameObject dialog;
    protected Player player;

    /// <summary>
    /// Closes the dialog.
    /// Optionally tries to update the player HUD if set
    /// This requires the dialog field to have been set or it will error.
    /// </summary>
    protected void CloseDialog()
    {
        Singleton.instance.Resume();
        if (player)
        {
            player.UpdateHUD();
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
