using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace WorseOfLife.Common.Configs
{
    public class TilesConfigs : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [DefaultValue(true)]
        public bool MiningIntoStone;
        [DefaultValue(true)]
        public bool TorchBrightness;
        [DefaultValue(true)]
        public bool CampfireDebuff;
        [DefaultValue(true)]
        public bool JarBee;
        [DefaultValue(true)]
        public bool HellstoneLavaSlime;
        [DefaultValue(true)]
        public bool Tombstoneaghost;
    }
}
