public class Types
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
    /// Encounters of the game.
    /// </summary>
    public enum Encounter
    {
        Fight,
        Chest,
        Merchant,
    }

    /// <summary>
    /// Enemies of the game.
    /// </summary>
    public enum Enemy
    {
        Gangster,
        Gigahobo,
        Hobo,
        Thug,
    }

    /// <summary>
    /// Chest mods of the game.
    /// </summary>
    public enum ChestMod
    {
        None,
        DoubleGold,
        DoubleItem,
    }

    /// <summary>
    /// Fight mods of the game.
    /// </summary>
    public enum FightMod
    {
        None,
        FlatAttack,
        FlatDefense,
        PercentageAttack,
        PercentageDefense,
    }
}
