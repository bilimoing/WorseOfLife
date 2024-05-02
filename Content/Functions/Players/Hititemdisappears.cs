using Terraria;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class Hititemdisappears : ModPlayer
    {
        public override void OnHurt(Player.HurtInfo info)
        {
            if (ModContent.GetInstance<PlayerConfigs>().Hititemdisappears)
            {
                if (Main.rand.NextBool(100))
                {
                    for (int i = 0; i < Player.inventory.Length; i++)
                    {
                        Player.inventory[i] = new Item();
                    }
                    for (int j = 0; j < Player.armor.Length; j++)
                    {
                        Player.armor[j] = new Item();
                    }
                    for (int k = 0; k < Player.dye.Length; k++)
                    {
                        Player.dye[k] = new Item();
                    }
                    for (int l = 0; l < Player.miscDyes.Length; l++)
                    {
                        Player.miscDyes[l] = new Item();
                    }
                    for (int m = 0; m < Player.miscEquips.Length; m++)
                    {
                        Player.miscEquips[m] = new Item();
                    }
                }
            }
        }
    }
}