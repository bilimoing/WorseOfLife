using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.NPCs.BossAI
{
    public class KingSlimeAI : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().BossAI)
            {
                if (npc.type == NPCID.KingSlime)
                {
                    if (npc.velocity.Y == 0f && npc.ai[1] <= 3f && npc.ai[2] < 300f && npc.ai[0] >= -10f && npc.ai[0] <= 0f)
                    {
                        npc.netUpdate = true;
                        npc.TargetClosest(true);
                        if (npc.ai[1] == 3f)
                        {
                            npc.velocity.Y = -13f;
                            npc.velocity.X += 3.5f * npc.direction;
                            npc.ai[0] = -120f;
                            npc.ai[1] = 0f;
                            npc.localAI[2] = 1f;
                        }
                        else if (npc.ai[1] == 2f)
                        {
                            npc.velocity.Y = -6f;
                            npc.velocity.X += 4.5f * npc.direction;
                            npc.ai[0] = -60f;
                            npc.ai[1] += 1f;
                        }
                        else
                        {
                            npc.velocity.Y = -8f;
                            npc.velocity.X += 4f * npc.direction;
                            npc.ai[0] = -60f;
                            npc.ai[1] += 1f;
                        }
                    }
                    if (npc.velocity.Y > 0f && npc.ai[0] < -60f && npc.life < npc.lifeMax * 0.5f && npc.ai[2] < 300f)
                    {
                        npc.velocity.X = 0f;
                        npc.velocity.Y += 15 * (1 + npc.life / npc.lifeMax);
                    }
                    if (npc.velocity.Y == 0f && npc.velocity.X == 0f && npc.life < npc.lifeMax * 0.5f && npc.ai[0] < -60f)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            Projectile.NewProjectile(null, new Vector2(npc.Center.X, npc.Center.Y + npc.height / 2), new Vector2(0f, 0f), ProjectileID.IceSpike, 7, 0f, 255, 0f, 0f);
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            Dust dust = Dust.NewDustDirect(new Vector2(npc.Center.X - npc.width * 2, npc.Center.Y + npc.height / 2), npc.width * 4, 1, DustID.Dirt, 0f, Main.rand.NextFloat(-5f, -1f), 0, default, 2f);
                            dust.noGravity = true;
                            dust.noLight = true;
                            dust.fadeIn = 1f;
                        }
                        if (npc.localAI[2] == 1f)
                        {
                            SoundEngine.PlaySound(SoundID.Item62, npc.Center);
                            npc.localAI[2] = 0f;
                        }
                    }
                }
            }
        }
    }
}

