class ModFlatAttack : ModFight
{
    private static int value = 4;

    public static string description = "Gain " + value + " attack for this fight.";

    public override EntityPlayer Apply(EntityPlayer entityPlayer)
    {
        return null;
    }
}
