using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using static khazix.Combo;
using static khazix.LaneClear;
using static khazix.JungleClear;

namespace khazix
{
    internal class Program
    {
        public static int SkinBase;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        public static void OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Khazix)
            {
                Chat.Print("<font color='#a0a0a0'>" + Player.Instance.Hero + "</font><font color='#957123'> is not supported!");
                return;
            }
            Chat.Print("<font color='#a0a0a0'>Kha'Zix by</font><font color='#957123'> twisteddebian<font color='#a0a0a0'> loaded!</font>");

            SkinBase = Player.Instance.SkinId;

            Game.OnTick += OnTick;
            Menus.CreateMenu();
            Spells.setupSpells();
            Drawings.CreateDrawings();
        }

        private static void OnTick(EventArgs args)
        {
           Common.Skinhack();
           if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)) ComboExecute();
           if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                LaneExecute();
            }
        }
    }
}
