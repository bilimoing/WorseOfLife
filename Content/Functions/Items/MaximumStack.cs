using Terraria;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Items
{
    public class MaximumStack : GlobalItem
    {
        public override bool InstancePerEntity => true;
        protected override bool CloneNewInstances => true;
        public override void SetDefaults(Item item)
        {
            if (ModContent.GetInstance<ItemsConfigs>().MaxStack)
            {
                item.maxStack = 1;
            }
        }
    }
}
