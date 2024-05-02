using System.Collections.Generic;
using Terraria.GameContent.Generation;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria;
using ReLogic.Utilities;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Maps
{
    public class RemoveShimmer : ModSystem
    {
        public override void PostWorldGen()
        {
            if (ModContent.GetInstance<MapConfigs>().RemoveShimmer)
            {
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    for (int j = 0; j < Main.maxTilesY; j++)
                    {
                        Tile tile = Main.tile[i, j];
                        if (tile.LiquidType == 3)
                        {
                            tile.LiquidType = 0;
                        }
                        if (tile.HasTile && tile.TileType == 659)
                        {
                            WorldGen.KillTile(i, j, false, false, false);
                        }
                    }
                }
            }
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {

            if (ModContent.GetInstance<MapConfigs>().RemoveShimmer)
            {
                int index = tasks.FindIndex((GenPass genPass) => genPass.Name.Equals("Shimmer"));
                if (index != -1)
                {
                    tasks.RemoveAt(index);
                }
                index = tasks.FindIndex((GenPass genPass) => genPass.Name.Equals("Altars"));
                if (index != -1)
                {
                    tasks.Insert(index, new PassLegacy("NoMoreShimmer: 移除微光", delegate (GenerationProgress _, GameConfiguration _)
                    {
                        int shimmerPositionYMin = (int)(Main.worldSurface + Main.rockLayer) / 2 + 50;
                        int shimmerPositionYMax = (int)((Main.maxTilesY - 250) * 2 + Main.rockLayer) / 3;
                        if (shimmerPositionYMax > Main.maxTilesY - 460)
                        {
                            shimmerPositionYMax = Main.maxTilesY - 460;
                        }
                        if (shimmerPositionYMax <= shimmerPositionYMin)
                        {
                            shimmerPositionYMax = shimmerPositionYMin + 50;
                        }
                        int shimmerPositionX = (GenVars.dungeonSide < 0) ? WorldGen.genRand.Next((int)(Main.maxTilesX * 0.89), Main.maxTilesX - 200) : WorldGen.genRand.Next(200, (int)(Main.maxTilesX * 0.11));
                        int shimmerPositionY = WorldGen.genRand.Next(shimmerPositionYMin, shimmerPositionYMax);
                        GenVars.shimmerPosition = new Vector2D(shimmerPositionX, shimmerPositionY);
                    }));
                }
            }
        }
    }
}
