using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;
using WorseOfLife.Common.GlobalProjectiles;

namespace WorseOfLife.Content.Functions.NPCs.BossAI
{
    public class EyeofCthulhuAI : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public int spawnTimer = 600;
        private const int MaxEyeNpcs = 12;
        private const int ProjectileType1 = 5;
        private const int ProjectileType3 = 12;
        private const int MaxCounterValue = 30;

        public override void AI(NPC npc)
        {
            if (npc.type == NPCID.EyeofCthulhu)
            {
                if (ModContent.GetInstance<NPCsConfigs>().BossAI)
                {

                    if (spawnTimer <= 0)
                    {
                        spawnTimer = 600;
                        if (npc.life <= npc.lifeMax * 1.0 && NPC.CountNPCS(ProjectileType1) < MaxEyeNpcs && Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            SpawnEyeNpcs(npc);
                        }
                        SoundEngine.PlaySound(SoundID.Item44, npc.Center);
                    }
                    if (npc.ai[1] == 3f)
                    {
                        HandleMovementAndAttack(npc, MaxCounterValue, ProjectileType3, 1.08f, 1.02f);
                    }
                }
            }
        }
        private void SpawnEyeNpcs(NPC npc)
        {
            if (npc.type == NPCID.EyeofCthulhu)
            {
                if (ModContent.GetInstance<NPCsConfigs>().BossAI)
                {

                    Vector2 vel = new(2f, 2f);
                    for (int i = 0; i < 4; i++)
                    {
                        int j = NPC.NewNPC(null, (int)(npc.position.X + npc.width / 2), (int)(npc.position.Y + npc.height), ProjectileType1, 0, 0f, 0f, 0f, 0f, 255);
                        if (j != 200)
                        {
                            Main.npc[j].velocity = vel.RotatedBy(1.5707963267948966 * i, default);
                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, j, 0f, 0f, 0f, 0, 0, 0);
                            }
                        }
                    }
                }
            }
        }
        private void HandleMovementAndAttack(NPC npc, int maxCounter, int projectileType, float horizontalVelModifier, float verticalVelModifier)
        {
            if (npc.type == NPCID.EyeofCthulhu)
            {
                if (ModContent.GetInstance<NPCsConfigs>().BossAI)
                {

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.velocity.X *= horizontalVelModifier;
                    }
                    npc.velocity.Y *= verticalVelModifier;
                    int num = spawnTimer + 1;
                    spawnTimer = num;
                    if (num >= maxCounter)
                    {
                        spawnTimer = 0;
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            VectorProjectiles.CircleSpin(projectileType, npc.Center, 83, 4.5f, npc.damage / 4, 0f);
                        }
                    }
                }
            }
        }
    }
}