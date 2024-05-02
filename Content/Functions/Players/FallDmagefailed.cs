using Terraria;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class FallDmagefailed : ModPlayer
    {
        public override void UpdateEquips()
        {
            if (ModContent.GetInstance<PlayerConfigs>().FallDmagefailed)
            {
                if (Player.noFallDmg)
                {
                    Player.noFallDmg = Main.rand.NextFloat() <= 0.5f;
                }
            }
        }
    }
}
