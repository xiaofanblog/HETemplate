using HesaEngine.SDK;
using SharpDX.DirectInput;

namespace ManiacTemplate
{
    public static class MenuManager
    {
        public static Menu Home, comboMenu, harassMenu, autoharassMenu, laneclearMenu, lasthitMenu, fleeMenu, drawingMenu, miscMenu, killstealMenu;
        
        private static string prefix = " - ";

        public static void LoadMenu()
        {
            Home = Menu.AddMenu("Maniac" + ObjectManager.Me.Hero);

            Main.orb = new Orbwalker.OrbwalkerInstance(Home.AddSubMenu("Orbwalker"));

            comboMenu = Home.AddSubMenu(prefix + "Combo");
            comboMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            comboMenu.Add(new MenuCheckbox("useW", "Use W", true));
            //comboMenu.Add(new MenuCheckbox("useE", "Use E", true));   //Not Applicable for Ashe
            comboMenu.Add(new MenuCheckbox("useR", "Use R", true));
            comboMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 50));

            harassMenu = Home.AddSubMenu(prefix + "Harass");
            harassMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            harassMenu.Add(new MenuCheckbox("useW", "Use W", true));
            //harassMenu.Add(new MenuCheckbox("useE", "Use E", true));  //Not Applicable for Ashe
            //harassMenu.Add(new MenuCheckbox("useR", "Use R", true));  //Not Applicable for Ashe
            harassMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 50));


            laneclearMenu = Home.AddSubMenu(prefix + "Lane Clear");
            laneclearMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            laneclearMenu.Add(new MenuCheckbox("useW", "Use W", true));
            //laneclearMenu.Add(new MenuCheckbox("useE", "Use E", true));   //Not Applicable for Ashe
            //laneclearMenu.Add(new MenuCheckbox("useR", "Use R", true));   //Not Applicable for Ashe
            laneclearMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 50));


            lasthitMenu = Home.AddSubMenu(prefix + "LastHit");
            //lasthitMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            lasthitMenu.Add(new MenuCheckbox("useW", "Use W", true));
            //lasthitMenu.Add(new MenuCheckbox("useE", "Use E", true)); //Not Applicable for Ashe
            //lasthitMenu.Add(new MenuCheckbox("useR", "Use R", true)); //Not Applicable for Ashe
            lasthitMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 50));


            fleeMenu = Home.AddSubMenu(prefix + "Flee");
            //fleeMenu.Add(new MenuCheckbox("useQ", "Use Q", true));    //Not Applicable for Ashe
            fleeMenu.Add(new MenuCheckbox("useW", "Use W", true));
            //fleeMenu.Add(new MenuCheckbox("useE", "Use E", true));    //Not Applicable for Ashe
            fleeMenu.Add(new MenuCheckbox("useR", "Use R", true));
            fleeMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 5));



            drawingMenu = Home.AddSubMenu(prefix + "Drawings");
            drawingMenu.Add(new MenuCheckbox("enable", "Enable", true));
            //drawingMenu.Add(new MenuCheckbox("drawQ", "Draw Q", true));   //Not Applicable for Ashe
            drawingMenu.Add(new MenuCheckbox("drawW", "Draw W", true));
            drawingMenu.Add(new MenuCheckbox("drawE", "Draw E", true));
            drawingMenu.Add(new MenuCheckbox("drawR", "Draw R", true));

            killstealMenu = Home.AddSubMenu(prefix + "KillSteal");
            killstealMenu.Add(new MenuCheckbox("enable", "Enable", true));
            //killstealMenu.Add(new MenuCheckbox("useQ", "Use Q", true));   //Not Applicable for Ashe
            killstealMenu.Add(new MenuCheckbox("useW", "Use W", true));
            //killstealMenu.Add(new MenuCheckbox("useE", "Use E", true));   //Not Applicable for Ashe
            killstealMenu.Add(new MenuCheckbox("useR", "Use R", true));
            killstealMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 10));


            miscMenu = Home.AddSubMenu(prefix + "Misc");
            miscMenu.Add(new MenuCheckbox("agW", "AntiGapclose W", true));
            miscMenu.Add(new MenuCheckbox("agR", "AntiGapclose R", true));
            miscMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 30));

        }

        public static bool GetCheckbox(this Menu menu, string value)
        {
            return menu.Get<MenuCheckbox>(value).Checked;
        }

        public static bool GetKeybind(this Menu menu, string value)
        {
            return menu.Get<MenuKeybind>(value).Active;
        }

        public static int GetSlider(this Menu menu, string value)
        {
            return menu.Get<MenuSlider>(value).CurrentValue;
        }

        public static int GetCombobox(this Menu menu, string value)
        {
            return menu.Get<MenuCombo>(value).CurrentValue;
        }
    }
}
