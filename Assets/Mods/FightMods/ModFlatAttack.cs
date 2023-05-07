class ModFlatAttack : ModFight
{
    private static int value = 4;

    public static string description = "Gain " + value + " attack for this fight.";

    public override EntityPlayer Apply(EntityPlayer entityPlayer)
    {
        EntityPlayer tempPlayer = Instantiate(entityPlayer);
        tempPlayer.ChangeAttackBy(4);
        return tempPlayer;
    }
}
