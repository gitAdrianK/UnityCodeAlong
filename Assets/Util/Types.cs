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
        Default,
        Fight,
        Chest,
        Merchant,
    }

    /// <summary>
    /// Chest mods of the game.
    /// </summary>
    public enum ChestMod
    {
        DoubleGold,
        DoubleItem,
    }

    /// <summary>
    /// Fight mods of the game.
    /// </summary>
    public enum FightMod
    {
        FlatAttack,
        FlatDefense,
        PercentageAttack,
        PercentageDefense,
    }
}
