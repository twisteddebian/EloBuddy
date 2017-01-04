using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static khazix.Menus;

namespace khazix
{
    internal class LaneClear
    {
        public static void LaneExecute()
        {
            var Qlanemonster = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.Q.Range);
            var Elanemonster = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.E.Range);

            if (LaneMenu["Q"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
            {
                if (Player.Instance.ManaPercent >= LaneMenu["MinManaQ"].Cast<Slider>().CurrentValue)
                {
                    foreach (var minion in Qlanemonster)
                    {
                        if (minion.IsValidTarget())
                        {
                            Spells.Q.Cast(minion);
                        }
                    }
                }
            }

            if (LaneMenu["W"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
            {
                foreach (var minion in Elanemonster)
                {
                    if (minion.IsValidTarget())
                    {
                        Spells.W.Cast(minion);
                    }
                }
            }

            //if (JungleMenu["mminsliderq"].Cast<Slider>().CurrentValue > Player.Instance.ManaPercent) return;
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