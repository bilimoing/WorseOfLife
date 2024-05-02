using Terraria;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Items
{
    public class Meleeweaponusemagic : GlobalItem
    {
        public override bool InstancePerEntity => true;
        protected override bool CloneNewInstances => true;
        public override void SetDefaults(Item item)
        {
            if (ModContent.GetInstance<ItemsConfigs>().Meleeweaponusemagic)
            {
                if (item.DamageType == DamageClass.Melee && item.axe == 0 && item.pick == 0 && item.hammer == 0)
                {
                    item.mana = 5;
                }
            }
        }
    }
}
