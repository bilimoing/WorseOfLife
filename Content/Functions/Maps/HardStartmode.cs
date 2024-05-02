using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Maps
{
    public class HardStartmode : ModSystem
    {
        public override void OnWorldLoad()
        {
            if (ModContent.GetInstance<MapConfigs>().HardStartmode)
            {
                if (!Main.hardMode)
                {
                    WorldGen.StartHardmode();
                }
            }
        }
    }
}
