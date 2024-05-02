using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class Breathingtime : ModPlayer
    {
        public override void PreUpdate()
        {
            if (ModContent.GetInstance<PlayerConfigs>().Breathingtime)
            {
                Player.breathMax = 30;
            }
        }
    }
}
