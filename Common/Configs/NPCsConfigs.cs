using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace WorseOfLife.Common.Configs
{
    public class NPCsConfigs : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [DefaultValue(true)]
        public bool BossAI;
        [DefaultValue(true)]
        public bool EmemyAI;
        [DefaultValue(true)]
        public bool NPCsDontDropItems;
        [DefaultValue(true)]
        public bool NPCsRecoversHP;
        [DefaultValue(true)]
        public bool NPCDropsMoney;
        [DefaultValue(true)]
        public bool NPCSdodgeprojectiles;
        [DefaultValue(true)]
        public bool TownNPCHostile;
    }
}
