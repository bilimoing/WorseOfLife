using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.NPCs.EmemyAI
{
    public class Vulture : GlobalNPC
    {
        private int attackTimer = 0; 
        private int attackInterval = 120;
        public override bool InstancePerEntity => true;
        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == NPCID.Vulture)
                {
                    attackTimer++; 

                    if (attackTimer >= attackInterval) 
                    {
                        WindBladeAttack(npc);

                        attackTimer = 0; 
                    }
                }
            }
        }
        private void WindBladeAttack(NPC npc)
        {
            Player player = Main.player[npc.target];
            Vector2 direction = Vector2.Normalize(player.Center - npc.Center);
            int damage = 15; 
            const int numBlades = 3;
            const float bladeSpeed = 12f; 

            for (int i = 0; i < numBlades; i++)
            {
                Vector2 velocity = direction.RotatedByRandom(MathHelper.ToRadians(30)); 
                Projectile.NewProjectile(null, npc.Center.X, npc.Center.Y, velocity.X * bladeSpeed, velocity.Y * bladeSpeed, 498, damage, 0f, Main.myPlayer);      
            }
        }
    }
}
