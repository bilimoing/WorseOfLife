using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace WorseOfLife.Common.Configs
{
    public class MapConfigs : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [DefaultValue(true)]
        public bool HardStartmode;
        [DefaultValue(true)]
        public bool ForcedMasterMode;
        [DefaultValue(true)]
        public bool RemoveShimmer;        
    }
}
