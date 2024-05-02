using Terraria.ModLoader;
using Terraria;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Players
{
    public class 翅膀飞行减半 : ModPlayer
    {
        public override void PostUpdateEquips()
        {
            if (ModContent.GetInstance<PlayerConfigs>().Wingflighttimehalved)
            {
                if (Player.wings > 0)
                {
                    Player.wingTimeMax /= 2;
                }
            }
        }
    }
}