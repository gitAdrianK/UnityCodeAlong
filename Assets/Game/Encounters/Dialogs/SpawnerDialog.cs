using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDialog : Dialog
{

    public void Initialize(GameObject dialog)
    {
        this.dialog = dialog;
    }

    public void Finished()
    {
        CloseDialog();
    }
}
