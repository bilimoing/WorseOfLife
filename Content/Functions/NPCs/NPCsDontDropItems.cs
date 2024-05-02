using Terraria;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.NPCs
{
    public class NPCsDontDropItems : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override bool PreKill(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().NPCsDontDropItems)
            {
                return !Main.rand.NextBool(10) && base.PreKill(npc);
            }
            return true;
        }
    }
}
