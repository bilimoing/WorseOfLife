using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class Luck : ModPlayer
    {
        public override void ModifyLuck(ref float luck)
        {
            if (ModContent.GetInstance<PlayerConfigs>().Luck)
            {
                if (Main.hardMode)
                {
                    luck -= 0.3f;
                }
            }
        }
    }
}
