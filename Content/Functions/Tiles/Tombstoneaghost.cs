using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Tiles
{
    internal class Tombstoneaghost : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (ModContent.GetInstance<TilesConfigs>().Tombstoneaghost)
            {
                if (type == TileID.Tombstones)
                {                    
                    NPC.NewNPC(null, i * 16, j * 16, NPCID.Ghost, 0, 0f, 0f, 0f, 0f, 255); 
                }
            }
        }
    }
}
