class ModPercentageAttack : ModFight
{
    private static int value = 10;

    public static string description = "Gain " + value + "% of attack as extra attack for this fight.";

    public override EntityPlayer Apply(EntityPlayer entityPlayer)
    {
        return null;
    }
}
