using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static khazix.Menus;
using System.Linq;

namespace khazix
{
    internal class Combo
    {
        public static void ComboExecute()
        {
            var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Physical);
            var rPred = Spells.E.GetPrediction(target);

            if ((target == null) || target.IsInvulnerable) return;

            //if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
            //{
                if (target.IsValidTarget(Spells.E.Range) && Spells.E.IsReady())
                {
                    Spells.E.Cast(target);
                }
           // }            

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
            {
                if (target.IsValidTarget(Spells.Q.Range) && Spells.Q.IsReady())
                {
                    Spells.Q.Cast(target);
                }
            }

            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
            {
                if (target.IsValidTarget(Spells.W.Range) && Spells.W.IsReady())
                {
                    var whitchance = Spells.W.GetPrediction(target);
                    if (whitchance.HitChancePercent >= 60)
                    {
                        Spells.W.Cast(whitchance.CastPosition);
                    }
                }
            }

            if (Activator["Hydra"].Cast<CheckBox>().CurrentValue)
            {
                if (Spells.Hydra.IsOwned() && Spells.Hydra.IsReady() && target.IsValidTarget(Spells.Q.Range))
                {
                    Spells.Hydra.Cast();
                }
                if (Spells.Hydra2.IsOwned() && Spells.Hydra2.IsReady() && target.IsValidTarget(Spells.Q.Range))
                {
                    Spells.Hydra2.Cast();
                }
                if (Spells.TitanicHydra.IsOwned() && Spells.TitanicHydra.IsReady() && target.IsValidTarget(Spells.Q.Range))
                {
                    Spells.TitanicHydra.Cast();
                }
                if (Spells.Tiamat.IsOwned() && Spells.Tiamat.IsReady() && target.IsValidTarget(Spells.Q.Range))
                {
                    Spells.Tiamat.Cast();
                }
                if (Spells.TiamatMelee.IsOwned() && Spells.TiamatMelee.IsReady() && target.IsValidTarget(Spells.Q.Range))
                {
                    Spells.TiamatMelee.Cast();
                }
            }

            //R usage, with enemies in range
            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue)
            {
                if (target.IsValidTarget(Spells.R.Range) && Spells.R.IsReady()
                    && Player.Instance.CountEnemiesInRange(600) == ComboMenu["REnemies"].Cast<Slider>().CurrentValue)
                {
                    Spells.R.Cast();
                }
            }
        }
    }
}