using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class HalvesMPHP : ModPlayer
    {
        public override void ResetEffects()
        {
            if (ModContent.GetInstance<PlayerConfigs>().HalvesMPHP)
            {
                Player.statManaMax2 /= 2;
                Player.statLifeMax2 /= 2;
            }
        }
    }
}
