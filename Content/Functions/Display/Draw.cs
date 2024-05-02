using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Display
{
    public class DrawNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        private int drawTimer;
        private bool shouldDraw;

        public override void AI(NPC npc)
        {
            if (ModContent.GetInstance<DisplayConfigs>().Draw)
            {
                drawTimer++;
                if (drawTimer >= 60)
                {
                    drawTimer = 0;
                    shouldDraw = Main.rand.NextBool(2);
                }
            }
        }
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (ModContent.GetInstance<DisplayConfigs>().Draw)
            {
                if (shouldDraw)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
    public class DrawUI : ModSystem
    {
        private int drawTimer;
        private bool shouldDrawUI;
        public override void UpdateUI(GameTime gameTime)
        {
            if (ModContent.GetInstance<DisplayConfigs>().Draw)
            {
                drawTimer++;
                if (drawTimer >= 60)
                {
                    drawTimer = 0;
                    shouldDrawUI = Main.rand.NextBool(2);
                }
                if (shouldDrawUI)
                {
                    Main.hideUI = true;
                }
                else
                {
                    Main.hideUI = false;
                }
            }
        }
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            if (ModContent.GetInstance<DisplayConfigs>().Draw)
            {
                drawTimer++;
                if (drawTimer >= 60)
                {
                    drawTimer = 0;
                    shouldDrawUI = Main.rand.NextBool(2);
                }

                if (shouldDrawUI)
                {
                    Main.hideUI = true;
                }
                else
                {
                    Main.hideUI = false;
                }
            }
        }
    }
}