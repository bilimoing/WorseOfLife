using System;
using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;
using Microsoft.Xna.Framework;

namespace WorseOfLife.Content.Functions.NPCs
{
    public class NPCSdodgeprojectiles : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().NPCSdodgeprojectiles)
            {
                Vector2 move = Vector2.Zero;
                for (int i = 0; i < 1000; i++)
                {
                    if (Main.projectile[i].friendly && Main.projectile[i].active && !Main.projectile[i].hide)
                    {
                        Main.projectile[i].velocity.Normalize();
                        if (Vector2.Dot(
                            Main.projectile[i].Center
                            - npc.Center,
                            Main.projectile[i].velocity) > 0f && (Main.projectile[i].Center - npc.Center).Length() > 100f || Math.Abs((double)(double)((Main.projectile[i].Center - npc.Center).X * Main.projectile[i].velocity.Y - (Main.projectile[i].Center - npc.Center).Y * Main.projectile[i].velocity.X)) > 280.0)
                        {
                            continue;
                        }
                        double tmpdis = (double)(120f / (Main.projectile[i].Center - npc.Center).Length());
                        move.X += (float)(tmpdis * Math.Cos((double)(double)(Math.Sign((double)(double)((Main.projectile[i].Center - npc.Center).X * Main.projectile[i].velocity.Y - (Main.projectile[i].Center - npc.Center).Y * Main.projectile[i].velocity.X)) * 1.5707964f + Utils.ToRotation(Main.projectile[i].velocity))));
                        move.Y += (float)(tmpdis * Math.Sin((double)(double)(Math.Sign((double)(double)((Main.projectile[i].Center - npc.Center).X * Main.projectile[i].velocity.Y - (Main.projectile[i].Center - npc.Center).Y * Main.projectile[i].velocity.X)) * 1.5707964f + Utils.ToRotation(Main.projectile[i].velocity))));
                    }
                }
                if (move.X != 0f || move.Y != 0f)
                {
                    move *= 0.4f;
                    if (move.Length() > 1f)
                    {
                        move.Normalize();
                    }
                    npc.velocity = Vector2.Lerp(npc.velocity, move * 36f, move.Length());
                }
            }
        }
    }
}

