using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;
using Terraria.ID;

namespace WorseOfLife.Content.Functions.NPCs.EmemyAI
{
    public class Piranha : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        private float speed = 7f;
        private float speedY = 4f;
        private float acceleration = 0.25f;
        private float accelerationY = 0.2f;
        private float correction = 0.95f;
        private bool targetDryPlayer = true;
        private bool bounces = true;
        private float idleSpeed = 2f;
        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == NPCID.Piranha)
                {
                    if (npc.direction == 0)
                    {
                        npc.TargetClosest(true);
                    }
                    if (npc.wet)
                    {
                        bool flag = false;
                        npc.TargetClosest(false);
                        if (Main.player[npc.target].wet && !Main.player[npc.target].dead)
                        {
                            flag = true;
                        }
                        if (!flag)
                        {
                            if (npc.collideX)
                            {

                                npc.velocity.X *= -1f;
                                npc.direction *= -1;
                                npc.netUpdate = true;
                            }
                            if (npc.collideY)
                            {
                                npc.netUpdate = true;
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = -npc.velocity.Y;
                                    npc.directionY = -1;
                                    npc.ai[0] = -1f;
                                }
                                else if (npc.velocity.Y < 0f)
                                {
                                    npc.velocity.Y = -npc.velocity.Y;
                                    npc.directionY = 1;
                                    npc.ai[0] = 1f;
                                }
                            }
                        }
                        if (flag)
                        {
                            npc.TargetClosest(true);
                            if (npc.velocity.X * npc.direction < 0f)
                            {

                                npc.velocity.X *= correction;
                            }

                            npc.velocity.X += npc.direction * acceleration;

                            npc.velocity.Y += npc.directionY * accelerationY;
                            if (npc.velocity.X > speed)
                            {
                                npc.velocity.X = speed;
                            }
                            if (npc.velocity.X < -speed)
                            {
                                npc.velocity.X = -speed;
                            }
                            if (npc.velocity.Y > speedY)
                            {
                                npc.velocity.Y = speedY;
                            }
                            if (npc.velocity.Y < -speedY)
                            {
                                npc.velocity.Y = -speedY;
                            }
                        }
                        else
                        {
                            if (targetDryPlayer)
                            {
                                if (Main.player[npc.target].position.Y > npc.position.Y)
                                {
                                    npc.directionY = 1;
                                }
                                else
                                {
                                    npc.directionY = -1;
                                }

                                npc.velocity.X += npc.direction * 0.1f * idleSpeed;
                                if (npc.velocity.X < -idleSpeed || npc.velocity.X > idleSpeed)
                                {

                                    npc.velocity.X = npc.velocity.X * 0.95f;
                                }
                                if (npc.ai[0] == -1f)
                                {
                                    float num = -0.3f * idleSpeed;
                                    if (npc.directionY < 0)
                                    {
                                        num = -0.5f * idleSpeed;
                                    }
                                    if (npc.directionY > 0)
                                    {
                                        num = -0.1f * idleSpeed;
                                    }

                                    npc.velocity.Y -= 0.01f * idleSpeed;
                                    if (npc.velocity.Y < num)
                                    {
                                        npc.ai[0] = 1f;
                                    }
                                }
                                else
                                {
                                    float num2 = 0.3f * idleSpeed;
                                    if (npc.directionY < 0)
                                    {
                                        num2 = 0.1f * idleSpeed;
                                    }
                                    if (npc.directionY > 0)
                                    {
                                        num2 = 0.5f * idleSpeed;
                                    }

                                    npc.velocity.Y += 0.01f * idleSpeed;
                                    if (npc.velocity.Y > num2)
                                    {
                                        npc.ai[0] = -1f;
                                    }
                                }
                            }
                            else
                            {

                                npc.velocity.X += npc.direction * 0.1f * idleSpeed;
                                if (npc.velocity.X < -idleSpeed || npc.velocity.X > idleSpeed)
                                {

                                    npc.velocity.X *= 0.95f;
                                }
                                if (npc.ai[0] == -1f)
                                {

                                    npc.velocity.Y -= 0.01f * idleSpeed;
                                    if (npc.velocity.Y < -0.3)
                                    {
                                        npc.ai[0] = 1f;
                                    }
                                }
                                else
                                {

                                    npc.velocity.Y += 0.01f * idleSpeed;
                                    if (npc.velocity.Y > 0.3)
                                    {
                                        npc.ai[0] = -1f;
                                    }
                                }
                            }
                            int num3 = (int)(npc.position.X + npc.width / 2) / 16;
                            int num4 = (int)(npc.position.Y + npc.height / 2) / 16;
                            if (Main.tile[num3, num4 - 1].LiquidAmount > 128)
                            {
                                if (Main.tile[num3, num4 + 1].HasTile)
                                {
                                    npc.ai[0] = -1f;
                                }
                                else if (Main.tile[num3, num4 + 2].HasTile)
                                {
                                    npc.ai[0] = -1f;
                                }
                            }
                            if (!targetDryPlayer && (npc.velocity.Y > 0.4 || npc.velocity.Y < -0.4))
                            {

                                npc.velocity.Y *= 0.95f;
                            }
                        }
                    }
                    else
                    {
                        if (npc.velocity.Y == 0f)
                        {
                            if (!bounces)
                            {

                                npc.velocity.X *= 0.94f;
                                if (npc.velocity.X > -0.2 && npc.velocity.X < 0.2)
                                {
                                    npc.velocity.X = 0f;
                                }
                            }
                            else if (Main.netMode != 1)
                            {
                                npc.velocity.Y = Main.rand.Next(-50, -20) * 0.1f;
                                npc.velocity.X = Main.rand.Next(-20, 20) * 0.1f;
                                npc.netUpdate = true;
                            }
                        }

                        npc.velocity.Y += 0.3f;
                        if (npc.velocity.Y > 10f)
                        {
                            npc.velocity.Y = 10f;
                        }
                        npc.ai[0] = 1f;
                    }
                    npc.rotation = npc.velocity.Y * npc.direction * 0.1f;
                    if (npc.rotation < -0.2)
                    {
                        npc.rotation = -0.2f;
                    }
                    if (npc.rotation > 0.2)
                    {
                        npc.rotation = 0.2f;
                    }
                }

            }
        }
    }
}
