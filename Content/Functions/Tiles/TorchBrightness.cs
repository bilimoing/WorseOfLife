using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Tiles
{
    public class TorchBrightness : GlobalTile
    {
        public override void ModifyLight(int i, int j, int type, ref float r, ref float g, ref float b)
        {
            if (ModContent.GetInstance<TilesConfigs>().TorchBrightness)
            {

                if (type == 4)
                {
                    r = 0.5f;// 修改火把的亮度值为0.5
                }
            }

        }
    }
}
