using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace WorseOfLife.Common.Configs
{
    public class ItemsConfigs : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [DefaultValue(true)]
        public bool FoodPoisoning;
        [DefaultValue(true)]
        [ReloadRequired]
        public bool BaitPowerHalved;
        [DefaultValue(true)]
        [ReloadRequired]
        public bool DoubleMP;
        [DefaultValue(true)]
        [ReloadRequired]
        public bool DamageDefault;
        [DefaultValue(true)]
        [ReloadRequired]
        public bool Meleeweaponusemagic;
        [DefaultValue(true)]
        [ReloadRequired]
        public bool AutoReuse;
        [DefaultValue(true)]
        [ReloadRequired]
        public bool CritChanceDecreased;
        [DefaultValue(true)]
        [ReloadRequired]
        public bool MaxStack;
        [DefaultValue(true)]
        [ReloadRequired]
        public bool FishingPowerHalved;
        [DefaultValue(true)]
        [ReloadRequired]
        public bool CopperPickaxe;
        [DefaultValue(true)]
        [ReloadRequired]
        public bool GravityPotionCooldown;
        [DefaultValue(true)]
        public bool Itemmovement;
    }
}
