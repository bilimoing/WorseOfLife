using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Display
{
    public class Thedowntheblack : ModSystem
    {
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            float t = 0f;
            Player localPlayer = Main.LocalPlayer;
            if (ModContent.GetInstance<DisplayConfigs>().Thedowntheblack)
            {
                if (localPlayer.ZoneDirtLayerHeight)
                {
                    t = 0.3f;
                }
                if (localPlayer.ZoneRockLayerHeight)
                {
                    t = 0.375f;
                }
                if (localPlayer.ZoneUnderworldHeight)
                {
                    t = 0.64f;
                }
                spriteBatch.Draw(TextureAssets.BlackTile.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * t);
            }
        }
    }
}
