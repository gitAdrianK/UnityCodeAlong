class ModPercentagedefense : ModFight
{
    private static int value = 10;

    public static string description = "Gain " + value + "% of defense as extra defense for this fight.";

    public override EntityPlayer Apply(EntityPlayer entityPlayer)
    {
        EntityPlayer tempPlayer = Instantiate(entityPlayer);
        tempPlayer.ChangeDefenseBy((int)(entityPlayer.Defense * 0.1f));
        return tempPlayer;
    }
}
