using Terraria.Localization;
using Terraria.ModLoader;

namespace WorseOfLife.Common.Systems
{
    public class EnglishSystem : ModSystem
    {
        public static bool English => Language.ActiveCulture != GameCulture.FromLegacyId(7);        
    }
}
