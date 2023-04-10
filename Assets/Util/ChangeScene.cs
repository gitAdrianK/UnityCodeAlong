using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Change scene.
/// </summary>
/// <seealso cref="MonoBehaviour" />
public class ChangeScene : MonoBehaviour
{
    /// <summary>
    /// Loads scene.
    /// Preferably use the method that takes a scene enum, it is not possible to
    /// serialize a private method to the unity inspector, but if it was this
    /// function would be private.
    /// </summary>
    /// <param name="index">The index.</param>
    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    /// <summary>
    /// Loads scene.
    /// </summary>
    /// <param name="scene">The scene.</param>
    public static void LoadScene(Types.Scene scene)
    {
        SceneManager.LoadScene((int)scene);
    }

    /// <summary>
    /// Closes game.
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }
}
