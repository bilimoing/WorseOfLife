using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.NPCs.BossAI
{
    public class QueenBeeAI : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().BossAI)
            {
                if (npc.type == NPCID.QueenBee)
                {
                    switch (npc.ai[0])
                    {
                        case 3f:
                            {
                                if (npc.ai[1] % 200f == 0f)
                                {
                                    SoundEngine.PlaySound(SoundID.Item17, npc.Center);
                                    if (Main.netMode != NetmodeID.MultiplayerClient)
                                    {
                                        int hornetID = 42;
                                        if (Main.rand.NextBool())
                                        {
                                            hornetID = Main.rand.Next(231, 235);
                                        }
                                        else
                                        {
                                            int randomInterval = Main.rand.Next(5);
                                            for (int i = -56; i >= -56 - 2 * randomInterval; i -= 2)
                                            {
                                                hornetID = i;
                                            }
                                        }
                                        Vector2 npcVelocity = npc.DirectionTo(Main.player[npc.target].Center) * 4f;
                                        int hornet = NPC.NewNPC(null, (int)npc.Center.X, (int)npc.Center.Y, hornetID, 0, 0f, 0f, 0f, 0f, 255);
                                        Main.npc[hornet].velocity = npcVelocity;
                                        Main.npc[hornet].netUpdate = true;
                                        for (int j = -6; j <= 6; j += 3)
                                        {
                                            int stinger = Projectile.NewProjectile(null, new Vector2(npc.Center.X, npc.Center.Y + npc.height), new Vector2(j, 8f), ProjectileID.HornetStinger, 10, 3f, 255, 0f, 0f);
                                            Main.projectile[stinger].tileCollide = false;
                                            Main.projectile[stinger].timeLeft = 300;
                                        }
                                    }
                                }

                                break;
                            }

                        case 0f when npc.ai[1] % 2f != 0f && npc.ai[2] != 1f && !hasCharged:
                            {
                                hasCharged = true;
                                SoundEngine.PlaySound(SoundID.Item17, npc.Center);
                                if (Main.netMode != NetmodeID.MultiplayerClient)
                                {
                                    for (int k = -8; k <= 8; k += 4)
                                    {
                                        int stinger2 = Projectile.NewProjectile(null, new Vector2(npc.Center.X + npc.width * 2 * npc.direction, npc.Center.Y), new Vector2(npc.velocity.X * 2f, k), ProjectileID.HornetStinger, 10, 3f, 255, 0f, 0f);
                                        Main.projectile[stinger2].tileCollide = false;
                                        Main.projectile[stinger2].timeLeft = 300;
                                    }
                                }

                                break;
                            }
                    }
                    if (npc.ai[0] == 0f && npc.ai[2] == 1f)
                    {
                        hasCharged = false;
                    }
                }
            }
        }
        private bool hasCharged;
    }
}
