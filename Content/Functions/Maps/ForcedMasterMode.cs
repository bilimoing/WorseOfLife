using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Maps
{
    public class ForcedMasterMode : ModSystem
    {
        public override void PostUpdateWorld()
        {
            if (ModContent.GetInstance<MapConfigs>().ForcedMasterMode)
            {
                Main.GameMode = 2;
            }
        }
    }
}
