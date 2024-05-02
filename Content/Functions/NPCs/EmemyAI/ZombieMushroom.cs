using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;
using Microsoft.Xna.Framework;

namespace WorseOfLife.Content.Functions.NPCs.EmemyAI
{
    public class ZombieMushroom : GlobalNPC
    {
        private int timer = 0;
        public override bool InstancePerEntity => true;
        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == NPCID.ZombieMushroom)
                {
                    npc.TargetClosest(true);
                    npc.netUpdate = true;
                    timer++;
                    if (timer == 120 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        timer = 0;
                        int ProjectileAmount = 6;
                        if (Main.masterMode)
                        {
                            ProjectileAmount = 8;
                        }
                        for (int i = 0; i < ProjectileAmount; i++)
                        {
                            Vector2 value17 = new(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                            value17.Normalize();
                            value17 *= Main.rand.Next(200, 500) * 0.01f;
                            int a = Projectile.NewProjectile(null, npc.Center.X, npc.Center.Y, value17.X, value17.Y, 131, 1, 1f);
                            Main.projectile[a].friendly = false;
                            Main.projectile[a].hostile = true;
                            Main.projectile[a].damage = 10;
                        }
                    }
                }
            }
        }
    }
}