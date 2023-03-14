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
    /// Scenes of the game.
    /// </summary>
    public enum Scene
    {
        // Make sure the order is the same as in the build settings.
        Mainmenu,
        CharacterSelection,
        Options,
        Game,
        GameOver,
    }

    /// <summary>
    /// Loads scene.
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
    public static void LoadScene(Scene scene)
    {
        LoadScene((int)scene);
    }

    /// <summary>
    /// Closes game.
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }
}
