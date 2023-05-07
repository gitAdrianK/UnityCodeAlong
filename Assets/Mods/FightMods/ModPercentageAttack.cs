class ModPercentageAttack : ModFight
{
    private static int value = 10;

    public static string description = "Gain " + value + "% of attack as extra attack for this fight.";

    public override EntityPlayer Apply(EntityPlayer entityPlayer)
    {
        EntityPlayer tempPlayer = Instantiate(entityPlayer);
        tempPlayer.ChangeAttackBy((int)(entityPlayer.Attack * 0.1f));
        return tempPlayer;
    }
}
