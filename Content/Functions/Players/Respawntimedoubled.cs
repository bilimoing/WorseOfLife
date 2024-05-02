using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class Respawntimedoubled : ModPlayer
    {
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (ModContent.GetInstance<PlayerConfigs>().Respawntimedoubled)
            {
                Player.respawnTimer = 3600;
            }
        }
    }
}
