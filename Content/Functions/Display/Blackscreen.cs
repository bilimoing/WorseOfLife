using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Display
{
    public class Blackscreen : ModSystem
    {
        private const float FadeDuration = 2f; // 变暗和恢复的渐变时长
        private const float BrightnessInterval = 30f; // 亮度变化的时间间隔
        private float brightnessTimer; // 亮度定时器，记录已经过去的时间
        private bool isDark; // 是否处于屏幕变暗状态
        private float fadeTimer; // 渐变时长计时器
        private Color darkColor = Color.Black; // 变暗颜色
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            if (ModContent.GetInstance<DisplayConfigs>().BlackScreen)
            {
                brightnessTimer += (float)Main._drawInterfaceGameTime.ElapsedGameTime.TotalSeconds;

                // 在亮度变化时间间隔内
                if (brightnessTimer <= BrightnessInterval)
                {
                    // 判断是否需要开始屏幕变暗
                    if (!isDark && brightnessTimer >= BrightnessInterval / 2f - FadeDuration)
                    {
                        isDark = true;
                        fadeTimer = FadeDuration;
                    }
                    // 判断是否需要开始恢复亮度
                    else if (isDark && brightnessTimer >= BrightnessInterval - FadeDuration)
                    {
                        isDark = false;
                        fadeTimer = FadeDuration;
                    }
                }
                // 重置定时器
                else if (brightnessTimer > BrightnessInterval + FadeDuration)
                {
                    brightnessTimer = 0f;
                }

                // 渐变处理
                if (fadeTimer > 0f)
                {
                    fadeTimer -= (float)Main._drawInterfaceGameTime.ElapsedGameTime.TotalSeconds;

                    float fadeAmount = 1f - fadeTimer / FadeDuration;
                    if (isDark)
                    {
                        darkColor.A = (byte)(fadeAmount * 255f);// 计算屏幕变暗的渐变比例
                    }
                    else
                    {
                        fadeAmount = 1 - fadeTimer / FadeDuration;
                    }
                    Main.spriteBatch.End();
                    Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(Main.UIScale, Main.UIScale, 1f));

                    if (isDark && fadeAmount > 0f)
                    {
                        Main.spriteBatch.Draw(TextureAssets.BlackTile.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * fadeAmount);
                    }
                    Main.spriteBatch.End();
                    Main.spriteBatch.Begin();
                }
            }
        }
    }
}