using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace WorseOfLife.Common.Configs
{
    public class PlayerConfigs : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [DefaultValue(true)]
        public bool Wingflighttimehalved;
        [DefaultValue(true)]
        public bool InitialHP;
        [DefaultValue(true)]
        public bool Fallingsuperslow;
        [DefaultValue(true)]
        public bool Defensehalved;
        [DefaultValue(true)]
        public bool Breathingtime;
        [DefaultValue(true)]
        public bool Respawntimedoubled;
        [DefaultValue(true)]
        public bool Luck;
        [DefaultValue(true)]
        public bool Hititemdisappears;
        [DefaultValue(true)]
        public bool Itemsdisappearafterdeath;
        [DefaultValue(true)]
        public bool HalvesMPHP;
        [DefaultValue(true)]
        public bool SlimeMount;
        [DefaultValue(true)]
        public bool Beatthegame;
        [DefaultValue(true)]
        public bool FallDmagefailed;
    }
}
