using HesaEngine.SDK;
using HesaEngine.SDK.GameObjects;
using static ManiacTemplate.SpellManager;
using static ManiacTemplate.MenuManager;

namespace ManiacTemplate.Modes
{
    public static class Combo
    {
        public static void DoCombo()
        {
            var q = ComboMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = ComboMenu.GetCheckbox("useW") && W.IsReady();
            var e = ComboMenu.GetCheckbox("useE") && E.IsReady();
            var r = ComboMenu.GetCheckbox("useR") && R.IsReady();
            AIHeroClient target;

            if (q)
            {
                target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);
                if (target != null)
                {
                    Q.CastIfHitchanceEquals(target, HitChance.Medium);
                }
            }
            
            if (w)
            {
                target = TargetSelector.GetTarget(W.Range, TargetSelector.DamageType.Physical);
                if (target != null)
                {
                    W.CastIfHitchanceEquals(target, HitChance.Medium);
                }
            }
        }
    }
}
