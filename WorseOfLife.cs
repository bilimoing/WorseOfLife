using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Achievements;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife
{
    public class WorseOfLife : Mod
    {
        public static WorseOfLife Mod { get; private set; } = ModContent.GetInstance<WorseOfLife>();
        public static Mod Instance;
        public static Ref<Effect> screenEffect;
        public static ScreenShaderData screenEff;
        public static Ref<Effect> screenEffect2;
        public static ScreenShaderData screenEff2;
        public static RenderTarget2D render;
        public static RenderTarget2D render2;

        [Obsolete]
        public override void Load()
        {
           
            Instance = this;
            screenEffect = new Ref<Effect>(ModContent.Request<Effect>("WorseOfLife/Textures/Shader/screenEffect", (ReLogic.Content.AssetRequestMode)1).Value);
            screenEff = new ScreenShaderData(screenEffect, "FilterMyShader");
            screenEffect2 = new Ref<Effect>(ModContent.Request<Effect>("WorseOfLife/Textures/Shader/screenEffect2", (ReLogic.Content.AssetRequestMode)1).Value);
            screenEff2 = new ScreenShaderData(screenEffect2, "FilterMyShader");
            Filters.Scene["Empty"] = new Filter(new ScreenShaderData(new Ref<Effect>(ModContent.Request<Effect>("WorseOfLife/Textures/Shader/screenEffectEmpty", (ReLogic.Content.AssetRequestMode)1).Value), "FilterMyShader"), (EffectPriority)2);
            Filters.Scene["Empty"].Load();
            On_Main.DrawInterface += new On_Main.hook_DrawInterface(Main_DrawInterface);
            base.Load();
        }
        public override void Unload()
        {
            Instance = null;
            On_Main.DrawInterface -= new On_Main.hook_DrawInterface(Main_DrawInterface);
            base.Unload();
        }
        
       
        protected void Main_DrawInterface(On_Main.orig_DrawInterface orig, Main self, GameTime gameTime)
        {
            if (Main.screenTarget != null && !Main.drawToScreen && Main.netMode != NetmodeID.Server && !Main.gameMenu && !Main.mapFullscreen && Lighting.NotRetro && Filters.Scene.CanCapture() && ModContent.GetInstance<DisplayConfigs>().TheShaderOrNot && !Main.screenTarget.IsContentLost && !Main.screenTarget.IsDisposed)
            {
                GraphicsDevice gd = Main.instance.GraphicsDevice;
                SpriteBatch sb = Main.spriteBatch;
                if (render == null || render.Width != Main.screenWidth || render.Height != Main.screenHeight)
                {
                    render = new RenderTarget2D(Main.graphics.GraphicsDevice, Main.screenWidth, Main.screenHeight);
                }
                gd.SetRenderTarget(render);
                sb.Begin(0, BlendState.Opaque);
                sb.Draw(Main.screenTarget, Vector2.Zero, Color.White);
                sb.End();
                orig.Invoke(self, gameTime);
                gd.Reset();
                if (render2 == null || render2.Width != Main.screenWidth || render2.Height != Main.screenHeight)
                {
                    render2 = new RenderTarget2D(Main.graphics.GraphicsDevice, Main.screenWidth, Main.screenHeight);
                }
                gd.SetRenderTarget(render2);
                sb.Begin((SpriteSortMode)1, BlendState.Opaque);
                screenEff.UseColor(50 / 50f, 50 / 50f, 50 / 70f);
                screenEff.UseOpacity(50 / 60f);
                screenEff.UseIntensity(50 / 50f);
                screenEff.Apply();
                sb.Draw(render, Vector2.Zero, Color.White);
                sb.End();
                gd.Reset();
                sb.Begin((SpriteSortMode)1, BlendState.Opaque);
                screenEff2.UseColor(50 / 50f, 1f, 1f);
                screenEff2.Apply();
                sb.Draw(render2, Vector2.Zero, Color.White);
                sb.End();
            }
            else
            {
                orig.Invoke(self, gameTime);
                if (!Filters.Scene["Empty"].IsActive())
                {
                    Filters.Scene.Activate("Empty", default, Array.Empty<object>());
                }
                return;
            }
        }
        public override void PostSetupContent()
        {

            if (ModLoader.TryGetMod("TMLAchievements", out Mod mod))
            {
                mod.Call(
                    "AddAchievement",
                    this, "Gel",
                    AchievementCategory.Collector,
                    "WorseOfLife/Textures/Achievements/GelMaster",
                    null,
                    false,
                    false,
                    1f,
                    new string[]
                    {
                        "Event_Gel",
                    });
                mod.Call(
                    "AddAchievement",
                    this,
                    "Ore",
                    AchievementCategory.Collector,
                    "WorseOfLife/Textures/Achievements/OreHunter",
                    null,
                    false,
                    false,
                    1.1f,
                    new string[]
                    {
                        "Event_Ore",
                    });
                mod.Call(
                    "AddAchievement",
                    this, "Chef",
                    AchievementCategory.Collector,
                    "WorseOfLife/Textures/Achievements/WildernessChef",
                    null,
                    false,
                    false,
                    1.2f,
                    new string[]
                    {
                        "Event_Chef",
                    });
                mod.Call(
                    "AddAchievement",
                    this, "Altar",
                    AchievementCategory.Explorer,
                    "WorseOfLife/Textures/Achievements/DarkBurst",
                    null,
                    false,
                    false,
                    1f,
                    new string[]
                    {
                        "Event_Altar",
                    });
            }
        }
    }
}