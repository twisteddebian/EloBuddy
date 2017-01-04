using System.Security.Cryptography.X509Certificates;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace khazix
{
    internal class Menus
    {
        public static Menu FirstMenu;
        public static Menu ComboMenu;
        public static Menu DrawingsMenu;
        public static Menu DamageIndicatorMenu;
        public static Menu LaneMenu;
        public static Menu Activator;
        public static Menu SkinChangerMenu;
        public static Menu JungleMenu;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu(Player.Instance.ChampionName, Player.Instance.ChampionName.ToLower() + "!");

            ComboMenu = FirstMenu.AddSubMenu("Combo Settings");
            DrawingsMenu = FirstMenu.AddSubMenu("Drawings");
            LaneMenu = FirstMenu.AddSubMenu("Lane Clear Settings");
            Activator = FirstMenu.AddSubMenu("Activator Settings");
            SkinChangerMenu = FirstMenu.AddSubMenu("Skin Settings");
            DamageIndicatorMenu = FirstMenu.AddSubMenu("Damage Indicator");
            LaneMenu = FirstMenu.AddSubMenu("Jungle Clear Settings");

            //LaneClear menu
            LaneMenu.AddGroupLabel("Lane Settings");
            LaneMenu.Add("Q", new CheckBox("Use Q"));
            LaneMenu.Add("W", new CheckBox("Use W"));
            LaneMenu.Add("MinManaQ", new Slider("Min Mana to cast Q", 30, 1, 99));

            //examples
            ComboMenu.AddGroupLabel("Combo Settings"); 
            ComboMenu.Add("Q", new CheckBox("Use Q"));
            ComboMenu.Add("W", new CheckBox("Use W"));
            ComboMenu.Add("E", new CheckBox("Use E"));
            ComboMenu.Add("R", new CheckBox("Use R"));
            ComboMenu.Add("EEnemies", new Slider("Count enemies for E", 3, 1, 5));
            ComboMenu.Add("REnemies", new Slider("Min enemies for R cast", 1, 1, 5));

            //drawings
            DrawingsMenu.AddGroupLabel("Drawings Settings");
            DrawingsMenu.Add("Q", new CheckBox("Draw Q"));
            DrawingsMenu.Add("W", new CheckBox("Draw W"));
            DrawingsMenu.Add("E", new CheckBox("Draw E"));
            DrawingsMenu.Add("R", new CheckBox("Draw R"));

            //skin menu
            SkinChangerMenu.AddGroupLabel("Skin");
            SkinChangerMenu.AddLabel("Skin Hack");
            SkinChangerMenu.Add("skinhack", new CheckBox("Activate Skin hack", false));
            SkinChangerMenu.Add("skinId", new ComboBox("Skin Mode", 0, "Classic", "Mecha Kha'Zix", "Guardian of the Sands Kha'Zix", "Death Blossom Kha'Zix"));

            //Activator Menu
            Activator.AddGroupLabel("Activator Settings");
            Activator.AddLabel("Supports only Hydra at the moment (All Hydra types & Tiamat)");
            Activator.Add("Hydra", new CheckBox("Use Hydra(all)"));

            //Damage Indicator Menu | needs to be added
            DamageIndicatorMenu.AddGroupLabel("Damage Indicator Settings");
            DamageIndicatorMenu.AddLabel("This will indicate how much Damage you'll deal!");
            DamageIndicatorMenu.Add("DIDrawings", new CheckBox("Enable/Disable D I drawings"));

            JungleMenu.AddGroupLabel("Jungle Clear Settings");
            LaneMenu.Add("Q", new CheckBox("Use Q"));
            LaneMenu.Add("W", new CheckBox("Use W"));
            JungleMenu.Add("mminsliderq", new Slider("If mana percent below {0}% stop use Q to jungleclear", 50));
            //JungleMenu.Add("mminsliderw", new Slider("If mana percent below {0}% stop use W to jungleclear", 50));
        }
    }
}