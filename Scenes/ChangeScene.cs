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
    /// Loads game with Pepe Maldini.
    /// </summary>
    public void LoadGameWithPepeMaldini()
    {
        InstantiatePlayerIfPossible("Pepe Maldini", 100, 10, 10, 0, null);
        LoadScene(Scene.Game);
    }

    /// <summary>
    /// Loads game with Zebra The Weebra.
    /// </summary>
    public void LoadGameWithZebraTheWeebra()
    {
        InstantiatePlayerIfPossible("Zebra The Weebra", 90, 5, 15, 50, null);
        LoadScene(Scene.Game);
    }

    /// <summary>
    /// Instantiates player if possible.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="life">The life.</param>
    /// <param name="attack">The attack.</param>
    /// <param name="defense">The defense.</param>
    /// <param name="gold">The gold.</param>
    /// <param name="items">The items.</param>
    private void InstantiatePlayerIfPossible(string name, int life, int attack, int defense, int gold, LinkedList<Item> items)
    {
        Singleton instance = Singleton.instance;
        if (!instance.entityPlayer)
        {
            instance.entityPlayer = (EntityPlayer)ScriptableObject.CreateInstance(typeof(EntityPlayer));
        }
        instance.entityPlayer.Initialize(name, life, attack, defense, gold, null);
    }

    /// <summary>
    /// Closes game.
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }
}
