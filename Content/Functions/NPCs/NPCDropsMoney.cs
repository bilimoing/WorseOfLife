using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.NPCs
{
    public class NPCDropsMoney : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override bool PreKill(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().NPCDropsMoney)
            {
                npc.value = 0f;
            }
            return true;
        }
    }
}
