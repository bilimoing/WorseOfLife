using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Items
{
    public class FoodPoisoning : GlobalItem
    {
        private int lastReviveCount;
        private int useCount;
        private double lastUseTime;
        public override bool InstancePerEntity => true;
        public override bool? UseItem(Item item, Player player)
        {
            double currentTime = Main.time / 60.0;
            if (ModContent.GetInstance<ItemsConfigs>().FoodPoisoning)
            {
                if (item.consumable && item.buffType > 0 && !item.potion && item.type != ItemID.ManaCrystal && item.type != ItemID.LifeCrystal && item.type != ItemID.LifeFruit)
                {
                    // 如果超过5分钟，则重置使用次数和时间
                    if (currentTime - lastUseTime > 5)
                    {
                        useCount = 0;
                        lastUseTime = currentTime;
                    }
                    if (player.GetModPlayer<FoodPoisoningPlayer>().reviveCount != lastReviveCount)
                    {
                        useCount = 0;
                        lastReviveCount = player.GetModPlayer<FoodPoisoningPlayer>().reviveCount;
                    }
                    useCount++;
                    // 如果在5分钟内已经使用了3次，则给玩家应用中毒效果
                    if (useCount > 3)
                    {
                        string category = "Strings";
                        Main.NewText(Mod.GetLocalization($"{category}.Foodpoisoning"));
                        player.AddBuff(ModContent.BuffType<Buffs.FoodPoisoning>(), 72000); // 中毒效果
                    }
                }
            }
            return true;
        }
    }
    public class FoodPoisoningPlayer : ModPlayer
    {
        public int reviveCount = 0;
        public override void OnRespawn() => reviveCount++;
    }
}
