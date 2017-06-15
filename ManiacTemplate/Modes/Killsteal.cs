using System.Linq;
using HesaEngine.SDK;
using static ManiacTemplate.SpellManager;
using static ManiacTemplate.MenuManager;

namespace ManiacTemplate.Modes
{
    public static class Killsteal
    {
        public static void DoKs()
        {
            var q = Q.IsReady() && KillstealMenu.GetCheckbox("useQ");
            var w = W.IsReady() && KillstealMenu.GetCheckbox("useW");
            var e = E.IsReady() && KillstealMenu.GetCheckbox("useE");
            var r = R.IsReady() && KillstealMenu.GetCheckbox("useR");
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x=> x.IsValidTarget(W.Range) && !x.IsDead && !x.IsZombie))
            {
                if (w && W.GetDamage(enemy) >= enemy.Health)
                    W.CastIfHitchanceEquals(enemy, HitChance.Medium);
            }
        }
    }
}
