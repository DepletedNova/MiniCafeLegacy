using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using static KitchenLib.Utils.GDOUtils;

namespace MiniCafeLegacy.Processes
{
    public class SteamProcess : CustomProcess
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "steam_milk";
        public override bool CanObfuscateProgress => true;
        public override int EnablingApplianceCount => 1;
        public override GameDataObject BasicEnablingAppliance => GetExistingGDO(ApplianceReferences.CoffeeMachine);
        public override List<(Locale, ProcessInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateProcessInfo("Steam", "<sprite name=\"steam_0\">"))
        };
    }
}
