using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using static khazix.Menus;

namespace khazix
{
    internal class JungleClear
    {
        public static void Clear()
        {
            if (JungleMenu["mminsliderq"].Cast<Slider>().CurrentValue > Player.Instance.ManaPercent ) return;
            if (JungleMenu["Q"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
            {
                var monster = ObjectManager.Get<Obj_AI_Minion>().Where(x => x.IsMonster && x.IsValidTarget(Spells.Q.Range)).OrderBy(x => x.MaxHealth).LastOrDefault();
                if (monster == null || !monster.IsValid) return;
                if (Orbwalker.IsAutoAttacking) return;
                Orbwalker.ForcedTarget = null;
                Spells.Q.Cast(monster);
            }
            if (JungleMenu["W"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
            {
                var monster = ObjectManager.Get<Obj_AI_Minion>().Where(x => x != null && x.IsMonster && x.IsValidTarget(Spells.W.Range)).OrderBy(x => x.MaxHealth).LastOrDefault();
                if (monster != null)
                {
                    Spells.W.Cast(monster);
                }
            }
        }
    }
}
