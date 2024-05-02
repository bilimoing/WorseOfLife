using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.NPCs
{
    public class NPCRecoversHP : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (ModContent.GetInstance<NPCsConfigs>().NPCsRecoversHP)
            {
                if (!npc.boss)
                {
                    switch (npc.friendly)
                    {
                        case false:
                            npc.lifeRegen += 10;
                            break;
                        default:
                            npc.lifeRegen = 0;
                            break;
                    }
                }
            }
        }
    }
}
