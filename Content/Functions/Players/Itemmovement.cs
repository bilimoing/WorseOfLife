using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class Itemmovement : ModPlayer
    {
        private int slot = 1;
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (ModContent.GetInstance<ItemsConfigs>().Itemmovement)
            {
                if (Player.whoAmI == Main.myPlayer)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        (Player.inventory[i], Player.inventory[slot * 10 + i]) = (Player.inventory[slot * 10 + i], Player.inventory[i]);
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncEquipment, -1, -1, null, Main.myPlayer, i, Main.player[Main.myPlayer].inventory[i].prefix, 0f, 0, 0, 0);
                            NetMessage.SendData(MessageID.SyncEquipment, -1, -1, null, Main.myPlayer, slot * 10 + i, Main.player[Main.myPlayer].inventory[slot * 10 + i].prefix, 0f, 0, 0, 0);
                        }
                    }                    
                    slot++;
                    if (slot > 4)
                    {
                        slot = 1;
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        int pos = Main.rand.Next(10, 50);
                        Item item = Player.inventory[pos];
                        Item item1 = Player.inventory[i];
                        Player.inventory[i] = item;
                        Player.inventory[pos] = item1;
                    }
                }               
            }
        }
    }
}
