using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using WorseOfLife.Common.Configs;

namespace WorseOfLife.Common.GlobalProjectiles
{
    public class VectorProjectiles : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public static Projectile[] CircleSpin(int num, Vector2 pos, int type, float speed, int damage, float knockback)
        {
            if (ModContent.GetInstance<NPCsConfigs>().BossAI)
            {
                Projectile[] projs = new Projectile[num];
                double spread = 6.283185307179586 / num;
                for (int i = 0; i < num; i++)
                {
                    projs[i] = NewProjectileDirectSafe(pos, new Vector2(speed, speed).RotatedBy(spread * i, default), type, damage, knockback, Main.myPlayer, 0f, 0f);
                }
                return projs;
            }
            return CircleSpin(num, pos, type, speed, damage, knockback);

        }
        public static Projectile[] CircleSpinRandom(int num, Vector2 pos, int type, float speed, int damage, float knockback)
        {
            if (ModContent.GetInstance<NPCsConfigs>().BossAI)
            {
                Projectile[] projs = new Projectile[num];
                double spread = Main.rand.Next(0, 360) * 3.141592653589793 / num;
                for (int i = 0; i < num; i++)
                {
                    projs[i] = NewProjectileDirectSafe(pos, new Vector2(speed, speed).RotatedBy(spread * i, default), type, damage, knockback, Main.myPlayer, 0f, 0f);
                }
                return projs;
            }
            return CircleSpinRandom(num, pos, type, speed, damage, knockback);
        }


        public static Projectile NewProjectileDirectSafe(Vector2 pos, Vector2 vel, int type, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f)
        {
            if (ModContent.GetInstance<NPCsConfigs>().BossAI)
            {
                int p = Projectile.NewProjectile(null, pos, vel, type, damage, knockback, owner, ai0, ai1);
                if (p >= 1000)
                {
                    return null;
                }
                return Main.projectile[p];
            }
            return NewProjectileDirectSafe(pos, vel, type, damage, knockback, owner, ai0, ai1);
        }
    }
}
