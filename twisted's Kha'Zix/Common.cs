using EloBuddy;
using EloBuddy.SDK.Menu.Values;
using static khazix.Menus;

namespace khazix
{
    internal class Common : Program
    {
        public static void Skinhack()
        {
            if (SkinChangerMenu["skinhack"].Cast<CheckBox>().CurrentValue)
            {
                Player.SetSkinId((int)SkinChangerMenu["skinId"].Cast<ComboBox>().CurrentValue);
            }
        }
    }
}
