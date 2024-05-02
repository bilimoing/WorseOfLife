using System;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;
using Microsoft.Xna.Framework;

namespace WorseOfLife.Content.Functions.NPCs.EmemyAI
{
    public class DarkCaster : GlobalNPC
    {
        public static Player GetTarget(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == NPCID.DarkCaster)
                {
                    return Main.player[npc.target];
                }
            }
            return Main.player[npc.target];
        }

        public static int GetTime1(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == NPCID.DarkCaster)
                {
                    return (int)npc.ai[2];
                }
            }
            return (int)npc.ai[2];
        }
        public static void SetTime1(NPC npc, int value)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == 32)
                {
                    npc.ai[2] = value;
                }
            }
        }
        public Vector2 pos;
        public override bool InstancePerEntity => true;
        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == NPCID.DarkCaster)
                {
                    if (npc.target < 0 || npc.target == 255 || GetTarget(npc).dead || !GetTarget(npc).active)
                    {
                        npc.TargetClosest(true);
                    }
                    int time = GetTime1(npc);
                    SetTime1(npc, time + 1);
                    npc.spriteDirection = (npc.direction = Utils.ToDirectionInt(npc.Center.X - GetTarget(npc).Center.X < 0f));
                    if (GetTime1(npc) == 300)
                    {
                        SoundEngine.PlaySound(SoundID.Item20, new Vector2?(npc.Center));
                        if (Main.netMode != 1)
                        {
                            Main.npc[NPC.NewNPC(npc.GetSource_Death(null), (int)npc.Center.X, (int)npc.Center.Y - 50, 34, 0, 0f, 0f, 0f, 0f, 255)].velocity = new Vector2(npc.direction * 10, 0f);
                            return;
                        }
                    }
                    else
                    {
                        if (GetTime1(npc) == 419)
                        {
                            for (int i = 0; i < 30; i++)
                            {
                                Dust dust = Dust.NewDustDirect(npc.Center + Utils.NextVector2Circular(Main.rand, 50f, 50f), 0, 0, DustID.DungeonWater, 0f, 0f, 0, default, 2f);
                                dust.noGravity = true;
                                dust.fadeIn = 1.2f;
                            }
                            return;
                        }
                        if (GetTime1(npc) > 420)
                        {
                            SetTime1(npc, 0);
                            bool flag = false;
                            int playerX = (int)GetTarget(npc).position.X / 16;
                            int playerY = (int)GetTarget(npc).position.Y / 16;
                            int npcX = (int)npc.position.X / 16;
                            int npcY = (int)npc.position.Y / 16;
                            int num = 20;
                            int num2 = 0;
                            SoundEngine.PlaySound(SoundID.Item20, new Vector2?(npc.Center));
                            if (Math.Abs(npc.position.X - GetTarget(npc).position.X) + Math.Abs(npc.position.Y - GetTarget(npc).position.Y) > 2000f)
                            {
                                num2 = 100;
                                flag = true;
                            }
                            while (!flag && num2 < 100)
                            {
                                num2++;
                                int targetX = Main.rand.Next(playerX - num, playerX + num);
                                int num3;
                                for (int j = Main.rand.Next(playerY - num, playerY + num); j < playerY + num2; j = num3 + 1)
                                {
                                    if ((j < playerY - 4 || j > playerY + 4 || targetX < playerX - 4 || targetX > playerX + 4) && (j < npcY - 1 || j > npcY + 1 || targetX < npcX - 1 || targetX > npcX + 1) && Main.tile[targetX, j].HasUnactuatedTile)
                                    {
                                        bool flag2 = true;
                                        if (Main.tile[targetX, j - 1].LiquidType == 1)
                                        {
                                            flag2 = false;
                                        }
                                        if (flag2 && Main.tileSolid[Main.tile[targetX, j].TileType] && !Collision.SolidTiles(targetX - 1, targetX + 1, j - 4, j - 1))
                                        {
                                            pos.X = targetX;
                                            pos.Y = j;
                                            flag = true;
                                            break;
                                        }
                                    }
                                    num3 = j;
                                }
                                if (pos.X != 0f && pos.Y != 0f)
                                {
                                    npc.position = new Vector2(pos.X * 16f - npc.width / 2 + 8f, pos.Y * 16f - npc.height);
                                }
                            }
                            for (int k = 0; k < 30; k++)
                            {
                                Dust dust2 = Dust.NewDustDirect(npc.Center + Utils.NextVector2Circular(Main.rand, 50f, 50f), 0, 0, DustID.DungeonWater, 0f, 0f, 0, default, 2f);
                                dust2.noGravity = true;
                                dust2.fadeIn = 1.2f;
                            }
                        }
                    }
                }
            }
        }
    }
}
