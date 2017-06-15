﻿using HesaEngine.SDK;
using static ManiacTemplate.SpellManager;
using static ManiacTemplate.MenuManager;

namespace ManiacTemplate.Modes
{
    public static class AntiGapcloser
    {
        public static void DoAntigapclose(ActiveGapcloser gapcloser)
        {
            if (gapcloser.Sender.IsAlly || gapcloser.Sender.IsDead || gapcloser.Sender.IsMe) return;

            var q = MiscMenu.GetCheckbox("agQ") && Q.IsReady();
            var w = MiscMenu.GetCheckbox("agW") && W.IsReady();
            var e = MiscMenu.GetCheckbox("agE") && E.IsReady();
            var r = MiscMenu.GetCheckbox("agR") && R.IsReady();

            if (w)
                W.CastIfHitchanceEquals(gapcloser.Sender, HitChance.Medium);
            
        }
    }
}
