using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace WorseOfLife.Content.Functions.NPCs.EmemyAI
{
    public class Werewolf : GlobalNPC
    {
        private int attackTimer = 0;
        private int attackInterval = 120;
        public override bool InstancePerEntity => true;
        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == NPCID.Werewolf)
                {
                    if (npc.HasValidTarget)
                    {
                        attackTimer++;
                        if (attackTimer >= attackInterval)
                        {
                            if (npc.Distance(Main.player[npc.target].Center) < 200)
                            {
                                SoundEngine.PlaySound(SoundID.Roar, npc.position);
                                for (int i = 0; i < Main.player.Length; i++)
                                {
                                    Player target = Main.player[i];
                                    if (target.active && Vector2.Distance(target.Center, npc.Center) < 200)
                                    {
                                        target.AddBuff(BuffID.Confused, 180);
                                    }
                                }
                                Vector2 direction = Main.player[npc.target].Center - npc.Center;
                                direction.Normalize();
                                Main.player[npc.target].velocity += direction * 1.05f;
                            }
                            attackTimer = 0;
                        }
                    }
                }
            }
        }
    }
}
