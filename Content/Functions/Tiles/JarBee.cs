using Terraria;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Tiles
{
    public class JarBee : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (ModContent.GetInstance<TilesConfigs>().JarBee)
            {
                if (!Main.hardMode)
                {
                    if (!NPC.downedQueenBee)
                    {
                        if (type == 28)
                        {
                            NPC.NewNPC(null, i * 16, j * 16, 210, 0, 0f, 0f, 0f, 0f, 255); // 在指定位置生成一个NPC，NPC类型为210
                        }
                    }
                    else
                    {
                        if (type == 28)
                        {
                            NPC.NewNPC(null, i * 16, j * 16, 42, 0, 0f, 0f, 0f, 0f, 255); // 在指定位置生成一个NPC，NPC类型为42
                        }
                    }
                }
                else
                {
                    if (!NPC.downedMoonlord)
                    {
                        if (type == 28)
                        {
                            NPC.NewNPC(null, i * 16, j * 16, -21, 0, 0f, 0f, 0f, 0f, 255); // 在指定位置生成一个NPC，NPC类型为-21
                        }
                    }
                    else
                    {
                        if (type == 28)
                        {
                            NPC.NewNPC(null, i * 16, j * 16, 427, 0, 0f, 0f, 0f, 0f, 255); // 在指定位置生成一个NPC，NPC类型为427
                        }
                    }
                }
            }
        }
    }
}
