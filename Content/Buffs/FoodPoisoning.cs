using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using WorseOfLife.Common.Systems;

namespace WorseOfLife.Content.Buffs
{
    public class FoodPoisoning : ModBuff
    {
        private int poisonDuration = 1; // 中毒的持续时间，60帧为1秒       
        private int poisonCounter = 0; // 中毒计数器
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        private string[] deathMessages = new string[]
        {
        EnglishSystem.English ? " ate too much and died" : "吃多了撑死了",
        EnglishSystem.English ? " was so hungry that he choked himself to death" : "由于太过饥饿，把自己撑死了",
        EnglishSystem.English ? " was crazy with hunger" : "饿疯了",
        };
        private string GetRandomDeathMessage()
        {
            int index = Main.rand.Next(deathMessages.Length);
            return deathMessages[index];
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.immune = false;
            player.immuneTime = 0;
            player.lifeRegenTime = 0;
            poisonCounter++;
            if (poisonCounter >= poisonDuration)
            {
                int damage = 1; // 每次中毒造成的伤害              
                PlayerDeathReason deathReason = PlayerDeathReason.ByCustomReason(player.name + GetRandomDeathMessage());
                player.Hurt(deathReason, damage, 0, false, false); // 无视无敌帧           
                poisonCounter = 0;
            }
        }
    }
}
