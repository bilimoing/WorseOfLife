using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class Beatthegame : ModPlayer
    {
        public override void OnHurt(Player.HurtInfo info)
        {
            if (ModContent.GetInstance<PlayerConfigs>().Beatthegame)
            {
                if (Main.rand.NextBool(10))
                {
                    Main.instance.Exit();
                }
            }
        }
    }
}
