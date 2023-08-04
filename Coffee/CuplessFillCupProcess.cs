using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using MiniCafeLegacy.Appliances;
using System.Collections.Generic;
using static KitchenLib.Utils.GDOUtils;

namespace MiniCafeLegacy.Processes
{
    public class CuplessFillCupProcess : CustomProcess
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "cupless_fill_cup";
        public override bool CanObfuscateProgress => true;
        public override int EnablingApplianceCount => 2;
        public override GameDataObject BasicEnablingAppliance => GetCustomGameDataObject<CuplessCoffeeMachine>().GameDataObject;
        public override Process IsPseudoprocessFor => GetGDO<Process>(ProcessReferences.FillCoffee);
        public override List<(Locale, ProcessInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateProcessInfo("Fill Cup", "<sprite name=\"fill_cup\">"))
        };
    }
}
