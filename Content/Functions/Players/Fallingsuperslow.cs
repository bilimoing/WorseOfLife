using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class Fallingsuperslow : ModPlayer
    {
        public override void PreUpdate()
        {
            if (ModContent.GetInstance<PlayerConfigs>().Fallingsuperslow)
            {
                Player.maxFallSpeed = 0.48f;
            }
        }
    }
}
