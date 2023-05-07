class ModDoubleGold : ModChest
{
    public static string description = "Doubles the gold in this chest.";

    public override void Apply(EncounterChest chest)
    {
        chest.Gold = chest.Gold * 2;
    }
}
