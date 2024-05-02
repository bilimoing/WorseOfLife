using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;
using Microsoft.Xna.Framework;

namespace WorseOfLife.Content.Functions.NPCs.EmemyAI
{
    public class LostGirl : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == NPCID.LostGirl)
                {
                    Vector2 target18 = npc.HasPlayerTarget ? Main.player[npc.target].Center : Main.npc[npc.target].Center;
                    if (npc.Distance(target18) <= 160f && attackTimer != 0f && npc.alpha != 0)
                    {
                        attackTimer = 0f;
                        npc.alpha = 0;
                        for (int i7 = 0; i7 < 20; i7++)
                        {
                            Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Smoke, 0f, 0f, 0, default, 1.5f);
                        }
                    }
                    if (npc.Distance(target18) >= 320f && attackTimer < 120f)
                    {
                        attackTimer += 1f;
                        if (attackTimer == 120f)
                        {
                            for (int i8 = 0; i8 < 20; i8++)
                            {
                                Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Smoke, 0f, 0f, 0, default, 1.5f);
                            }
                            npc.alpha = 255;
                        }
                    }
                }
            }
        }
        private float attackTimer;
    }
}
