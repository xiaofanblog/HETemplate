using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using ManiacTemplate.Modes;
using static ManiacTemplate.SpellManager;
using static ManiacTemplate.MenuManager;
using static ManiacTemplate.DrawingManager;

namespace ManiacTemplate
{
    public class Main : IScript
    {
        //Don't forget to change the champion first!
        private const Champion Champion = HesaEngine.SDK.Enums.Champion.Ashe;

        public string Name => "Maniac" + Champion;

        public string Version => "1.0.0";

        public string Author => "BoliBerrys";

        public static PredictionInput QPred, WPred, EPred, RPred;

        public static Orbwalker.OrbwalkerInstance Orb => Core.Orbwalker;

        public void OnInitialize()
        {
            Game.OnGameLoaded += Game_OnGameLoaded;
        }

        private void Game_OnGameLoaded()
        {
            if (ObjectManager.Me.Hero != Champion)
                return;

            LoadMenu();

            LoadSpells();

            HesaEngine.SDK.AntiGapcloser.OnEnemyGapcloser += Modes.AntiGapcloser.DoAntigapclose;

            LoadDrawings();

            Game.OnTick += Game_OnTick;
            Chat.Print(Name + " Loaded Successfully");
        }

        private static void Game_OnTick()
        {
            var mana = ObjectManager.Me.ManaPercent;

            if (KillstealMenu.GetCheckbox("enable"))
                Killsteal.DoKs();

            if (Orb.ActiveMode == Orbwalker.OrbwalkingMode.Combo && mana >= ComboMenu.GetSlider("mana"))
                Combo.DoCombo();

            if (Orb.ActiveMode == Orbwalker.OrbwalkingMode.Harass && mana >= HarassMenu.GetSlider("mana"))
                Harass.DoHarass();

            if (Orb.ActiveMode == Orbwalker.OrbwalkingMode.LaneClear && mana >= LaneclearMenu.GetSlider("mana"))
                LaneClear.DoLaneClear();

            if (Orb.ActiveMode == Orbwalker.OrbwalkingMode.LastHit && mana >= LasthitMenu.GetSlider("mana"))
                LaneClear.DoLaneClear();

            if (Orb.ActiveMode == Orbwalker.OrbwalkingMode.Flee && mana >= FleeMenu.GetSlider("mana"))
                Flee.DoFlee();
            
        }
    }
}
