class ModFlatDefense : ModFight
{
    private static int value = 4;

    public static string description = "Gain " + value + " defense for this fight.";

    public override EntityPlayer Apply(EntityPlayer entityPlayer)
    {
        EntityPlayer tempPlayer = Instantiate(entityPlayer);
        tempPlayer.ChangeDefenseBy(4);
        return tempPlayer;
    }
}
