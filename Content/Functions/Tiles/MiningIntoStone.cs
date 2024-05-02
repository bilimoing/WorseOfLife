using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Tiles
{
    public class MiningIntoStone : GlobalTile
    {
        private readonly int convertChance = 10; // 转换为石头的几率（百分比）

        // 在方块掉落时调用的方法
        public override void Drop(int i, int j, int type)
        {
            if (ModContent.GetInstance<TilesConfigs>().MiningIntoStone)
            {
                if (TileID.Sets.Ore[type]) // 如果掉落的方块是矿石
                {
                    if (ShouldConvert()) // 根据转换几率判断是否进行转换
                    {
                        Main.tile[i, j].TileType = TileID.Stone; // 将方块类型转换为石头
                        WorldGen.SquareTileFrame(i, j, true); // 更新方块的图像和动画
                        NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None); // 向客户端发送方块变化的消息
                    }
                }
            }
        }

        // 判断是否进行转换的方法
        private bool ShouldConvert()
        {
            int random = Main.rand.Next(100); // 生成一个0-99的随机数
            return random < convertChance; // 如果随机数小于转换几率，返回true，否则返回false
        }
    }
}
