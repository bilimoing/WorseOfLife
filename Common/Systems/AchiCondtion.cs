using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WorseOfLife.Common.Systems
{
    public class AchiCondtion : ModPlayer
    {        
        public override void PostUpdate()
        {
            if (ModLoader.TryGetMod("TMLAchievements", out Mod mod))
            {
                int gelCount = Player.GetItemCount(ItemID.Gel);
                if (gelCount >= 10000)
                {                   
                    mod.Call("Event", "Gel");
                }
                if (Player.HasItem(4555) && Player.HasItem(4556) && Player.HasItem(4557))
                {
                    mod.Call("Event", "Chef");                    
                }
                if (Player.HasItem(11) && Player.HasItem(12) && Player.HasItem(13) && Player.HasItem(14) && Player.HasItem(173) && Player.HasItem(174) && Player.HasItem(174) && Player.HasItem(699) && Player.HasItem(700) && Player.HasItem(701) && Player.HasItem(702) && Player.HasItem(56) && Player.HasItem(116) && Player.HasItem(880) && Player.HasItem(364) && Player.HasItem(365) && Player.HasItem(366) && Player.HasItem(1104) && Player.HasItem(1105) && Player.HasItem(1106) && Player.HasItem(947) && Player.HasItem(3460))
                {
                    mod.Call("Event", "Ore");                   
                }
                if (WorldGen.altarCount == 0) 
                {
                    mod.Call("Event","Altar");
                }
            }
        }
    }

    public static class PlayerExtensions
    {
        public static int GetItemCount(this Player player, int itemId)
        {
            int count = 0;

            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i].type == itemId)
                {
                    count += player.inventory[i].stack;
                }
            }

            return count;
        }
    }
}
