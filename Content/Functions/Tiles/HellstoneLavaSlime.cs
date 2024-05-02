using Terraria;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Tiles
{
    public class HellstoneLavaSlime : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (ModContent.GetInstance<TilesConfigs>().HellstoneLavaSlime)
            {

                if (type == 58)
                {
                    NPC.NewNPC(null, i * 16, j * 16, 59, 0, 0f, 0f, 0f, 0f, 255); // 在指定位置生成类型为59的NPC
                }
            }
        }
    }
}
