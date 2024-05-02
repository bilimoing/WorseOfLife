using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;
using Microsoft.Xna.Framework;

namespace WorseOfLife.Content.Functions.NPCs.EmemyAI
{
    public class ToxicSludge : GlobalNPC
    {

        public override bool InstancePerEntity => true;
        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == NPCID.ToxicSludge)
                {
                    Lighting.AddLight(npc.position, new Vector3(0.15f, 0.75f, 0.1f));
                    if (npc.localAI[0] > 0f)
                    {
                        npc.localAI[0] -= 1f;
                    }
                    npc.direction = Main.player[npc.target].Center.X < npc.Center.X ? -1 : 1;
                    if (!npc.wet && !Main.player[npc.target].npcTypeNoAggro[npc.type])
                    {
                        Vector2 vector5 = new(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.1f);
                        float num17 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector5.X;
                        float num18 = Main.player[npc.target].position.Y - vector5.Y;
                        float num19 = (float)Math.Sqrt((double)(num17 * num17 + num18 * num18));
                        if (Main.expertMode && num19 < 200f && Collision.CanHit(new Vector2(npc.position.X, npc.position.Y - 20f), npc.width, npc.height + 20, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height) && npc.velocity.Y == 0f)
                        {
                            npc.ai[0] = -40f;
                            if (npc.velocity.Y == 0f)
                            {
                                npc.velocity.X *= 0.9f;
                            }
                            if (npc.localAI[0] == 0f && Main.netMode != 1)
                            {
                                for (int num20 = 0; num20 < 5; num20++)
                                {
                                    Vector2 vector6 = new(num20 - 2, -2f);
                                    vector6.X *= 1f + Main.rand.Next(-50, 51) * 0.02f;
                                    vector6.Y *= 1f + Main.rand.Next(-50, 51) * 0.02f;
                                    vector6.Normalize();
                                    vector6 *= 3f + Main.rand.Next(-50, 51) * 0.01f;
                                    Projectile.NewProjectile(null, vector5.X, vector5.Y, vector6.X, vector6.Y, 55, (int)(npc.damage * 0.33f), 0f, Main.myPlayer, 0f, 0f);
                                    npc.localAI[0] = 80f;
                                }
                            }
                        }
                        if (num19 < 400f && Collision.CanHit(new Vector2(npc.position.X, npc.position.Y - 20f), npc.width, npc.height + 20, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height) && npc.velocity.Y == 0f)
                        {
                            npc.ai[0] = -80f;
                            if (npc.velocity.Y == 0f)
                            {
                                npc.velocity.X *= 0.9f;
                            }
                            if (npc.localAI[0] == 0f && Main.netMode != 1)
                            {
                                num18 = Main.player[npc.target].position.Y - vector5.Y - Main.rand.Next(-30, 20);
                                num18 -= num19 * 0.05f;
                                num17 = Main.player[npc.target].position.X - vector5.X - Main.rand.Next(-20, 20);
                                num19 = (float)Math.Sqrt((double)(num17 * num17 + num18 * num18));
                                num19 = 7f / num19;
                                num17 *= num19;
                                num18 *= num19;
                                npc.localAI[0] = 65f;
                                Projectile.NewProjectile(null, vector5.X, vector5.Y, num17, num18, 55, (int)(npc.damage * 0.33f), 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                }
            }
        }
    }
}
