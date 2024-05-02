using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class InitialHP : ModPlayer
    {
        public override void OnRespawn()
        {
            if (ModContent.GetInstance<PlayerConfigs>().InitialHP)
            {
                Player.statLife = 1;
            }
        }
    }
}
