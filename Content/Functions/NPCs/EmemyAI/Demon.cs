using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;
using Microsoft.Xna.Framework;

namespace WorseOfLife.Content.Functions.NPCs.EmemyAI
{
    public class Demon : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<NPCsConfigs>().EmemyAI)
            {
                if (npc.type == NPCID.Demon)
                {
                    npc.TargetClosest(true);
                    Entity entity = Main.player[npc.target];
                    Vector2 position = Main.player[npc.target].position;
                    Vector2 Locate = entity.Center - npc.Center;
                    float magnitude = (float)Math.Sqrt((double)(Locate.X * Locate.X + Locate.Y * Locate.Y));
                    Locate *= 4.4f / magnitude;
                    npc.velocity = Locate;
                    npc.spriteDirection = npc.direction;
                }
            }
        }
    }
}
