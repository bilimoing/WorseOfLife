using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class SlimeMount : ModPlayer
    {
        public override void PreUpdate()
        {
            if (ModContent.GetInstance<PlayerConfigs>().SlimeMount)
            {

                for (int i = 0; i < Main.player.Length; i++)
                {
                    if (Main.player[i].mount.Active && Main.player[i].mount.IsConsideredASlimeMount)
                    {
                        Main.player[i].noFallDmg = true;
                    }
                }
            }
        }
    }
}
