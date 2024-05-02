using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Items
{
    public class CopperPickaxe : GlobalItem
    {
        public override bool InstancePerEntity => true;
        protected override bool CloneNewInstances => true;
        public override void SetDefaults(Item item)
        {
            if (ModContent.GetInstance<ItemsConfigs>().CopperPickaxe)
            {

                if (item.type == ItemID.CopperPickaxe)
                {
                    item.useTime = 5;
                    item.useAnimation = 5;
                    item.pick = 5;
                }
            }
        }
    }
}
