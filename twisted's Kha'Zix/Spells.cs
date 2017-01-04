using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace khazix
{
    internal static class Spells
    {
        public static Spell.Targeted Q;
        public static Spell.Skillshot W;
        public static Spell.Skillshot E;
        public static Spell.Active R;

        public static void setupSpells()
        {
            Q = new Spell.Targeted(SpellSlot.Q, 425);
            W = new Spell.Skillshot(SpellSlot.W, 1000, SkillShotType.Cone);
            E = new Spell.Skillshot(SpellSlot.E, 700, SkillShotType.Cone);
            R = new Spell.Active(SpellSlot.R, 25000);
        }

        public static Item Hydra = new Item(ItemId.Ravenous_Hydra_Melee_Only, 250);
        public static Item TitanicHydra = new Item(ItemId.Titanic_Hydra, 250);
        public static Item Hydra2 = new Item(ItemId.Ravenous_Hydra, 250);
        public static Item Tiamat = new Item(ItemId.Tiamat, 250);
        public static Item TiamatMelee = new Item(ItemId.Tiamat_Melee_Only, 250);

        public static List<Item> ItemList = new List<Item>
        {
            Hydra,
            TitanicHydra,
            Hydra2,
            Tiamat,
            TiamatMelee
        };
    }
}