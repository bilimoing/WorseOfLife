using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class Defensehalved : ModPlayer
    {
        public override void ResetEffects()
        {
            if (ModContent.GetInstance<PlayerConfigs>().Defensehalved)
            {
                Player.statDefense /= 2;
            }
        }
    }
}
