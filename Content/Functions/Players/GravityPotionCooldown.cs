using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class GravityPotionCooldown : ModPlayer
    {
        private float PrevGravDir = 1f;
        private int GravChangeDelay;
        public override void PreUpdate()
        {
            if (ModContent.GetInstance<ItemsConfigs>().GravityPotionCooldown)
            {
                if (Player.gravControl && Player.HasBuff(18))
                {
                    if (GravChangeDelay > 0)
                    {
                        if (PrevGravDir == -1f && Player.gravDir == 1f)
                        {
                            Player.gravDir = -1f;
                        }
                        else if (PrevGravDir == 1f && Player.gravDir == -1f)
                        {
                            Player.gravDir = 1f;
                        }
                        GravChangeDelay--;
                    }
                    else if (PrevGravDir != Player.gravDir)
                    {
                        PrevGravDir = Player.gravDir;
                        GravChangeDelay = 300;
                    }
                }
            }
        }
    }
}