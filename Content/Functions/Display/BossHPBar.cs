using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Display
{
    public class BossHPBar : GlobalBossBar
    {

        public override bool PreDraw(SpriteBatch spriteBatch, NPC npc, ref BossBarDrawParams drawParams)
        {
            if (ModContent.GetInstance<DisplayConfigs>().BossHPBar)
            {
                return false;
            }
            return true;
        }
        public override void PostDraw(SpriteBatch spriteBatch, NPC npc, BossBarDrawParams drawParams)
        {
            base.PostDraw(spriteBatch, npc, drawParams);
        }
    }
}
