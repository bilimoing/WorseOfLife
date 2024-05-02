using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;
using Microsoft.Xna.Framework;

namespace WorseOfLife.Content.Functions.NPCs.EmemyAI
{
    public class Bee : GlobalNPC
    {
        private bool attacking = false;
        private int attackTimer = 0;
        public override bool InstancePerEntity => true;
        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == NPCID.Bee)
                {
                    Player player = Main.player[npc.target];
                    if (npc.position.X <= (double)player.position.X + 20 && npc.position.X >= (double)player.position.X - 20 && npc.position.Y < (double)player.position.Y)
                    {
                        if (Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1))
                        {
                            attacking = true;
                        }
                    }
                    if (attacking)
                    {
                        npc.velocity.X = 0;
                        npc.velocity.Y = 0;
                        attackTimer++;
                        npc.direction = npc.spriteDirection;
                        if (player.position.X > (double)npc.position.X)
                            npc.spriteDirection = 1;
                        else if (player.position.X < (double)npc.position.X)
                            npc.spriteDirection = -1;
                        if (attackTimer % (Main.masterMode ? 14 : 18) == 0)
                        {
                            SoundEngine.PlaySound(SoundID.Item17, npc.position);
                            Vector2 player2 = player.Center;
                            Vector2 vector2_1 = player2;
                            float speed = 10f;
                            Vector2 vector2_2 = vector2_1 - npc.Center;
                            float distance = (float)System.Math.Sqrt(vector2_2.X * (double)vector2_2.X + vector2_2.Y * (double)vector2_2.Y);
                            vector2_2 *= speed / distance;
                            Projectile.NewProjectile(null, npc.Center.X, npc.Center.Y + 20, vector2_2.X, vector2_2.Y, 55, npc.damage / 3, 5.0f, 0, 0.0f, 0.0f);

                        }
                        if (attackTimer == 180)
                        {
                            attackTimer = 0;
                            attacking = false;
                        }
                    }
                }
            }
        }
        public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo hurtInfo)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == NPCID.Bee && npc.type == NPCID.BeeSmall)
                {
                    target.AddBuff(BuffID.Venom, Main.masterMode ? 180 : 120);
                }
            }
        }
    }
}

