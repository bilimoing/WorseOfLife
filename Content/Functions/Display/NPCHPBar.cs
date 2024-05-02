using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Content.Functions.Display
{
    public class NPCHPBar : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override bool? DrawHealthBar(NPC npc, byte hbPosition, ref float scale, ref Vector2 position)
        {
            if (ModContent.GetInstance<DisplayConfigs>().NPCHPBar)
            {
                return new bool?(false);
            }
            return true;
        }
    }   
}
