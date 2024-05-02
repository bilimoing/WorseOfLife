using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace WorseOfLife.Common.Configs
{
    public class DisplayConfigs : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [DefaultValue(true)]
        public bool BossHPBar;
        [DefaultValue(true)]
        public bool NPCHPBar;
        [DefaultValue(true)]
        public bool BlackScreen;
        [DefaultValue(true)]
        public bool Thedowntheblack;
        [DefaultValue(true)]
        public bool Draw;
        [DefaultValue(true)]
        public bool TheShaderOrNot;
    }
}
