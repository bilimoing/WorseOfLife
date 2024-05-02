using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.NPCs
{
    public class TownNPCHostile : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().TownNPCHostile)
            {
                if (!npc.boss)
                {
                    if (npc.townNPC && npc.friendly)
                    {
                        npc.friendly = false;
                        if (!Main.dayTime)
                        {
                            npc.aiStyle = 3;
                        }
                        else
                        {
                        }
                        if (npc.type == NPCID.Wizard)
                        {
                            npc.aiStyle = 8;
                        }
                    }
                    else
                    {
                    }
                }

            }
        }
    }
}
