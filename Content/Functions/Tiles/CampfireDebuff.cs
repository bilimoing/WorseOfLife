using Terraria;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Tiles
{
    public class CampfireDebuff : GlobalTile
    {
        public override void NearbyEffects(int i, int j, int type, bool closer)
        {
            if (ModContent.GetInstance<TilesConfigs>().CampfireDebuff)
            {
                Player p = Main.LocalPlayer;
                if (type == 215 && closer && Main.tile[i, j].TileFrameY < 10)
                {
                    p.AddBuff(24, 10, true);// 给玩家添加一个持续时间为10帧的Buff（状态效果），Buff的ID为24
                }
            }
        }
    }
}
