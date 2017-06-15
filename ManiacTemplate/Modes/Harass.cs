using HesaEngine.SDK;
using static ManiacTemplate.MenuManager;
using static ManiacTemplate.SpellManager;

namespace ManiacTemplate.Modes
{
    public static class Harass
    {
        public static void DoHarass()
        {
            var q = HarassMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = HarassMenu.GetCheckbox("useW") && W.IsReady();
            var e = HarassMenu.GetCheckbox("useE") && E.IsReady();
            var r = HarassMenu.GetCheckbox("useR") && R.IsReady();

            var target = TargetSelector.GetTarget(W.Range, TargetSelector.DamageType.Physical);

            if (w)
                W.CastIfHitchanceEquals(target, HitChance.Medium);
        }
    }
}
