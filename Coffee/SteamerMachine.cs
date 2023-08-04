using ApplianceLib.Api;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using MiniCafe.Appliances;
using MiniCafe.Extras;
using MiniCafe.Items;
using MiniCafe.Processes;
using MiniCafeLegacy.Processes;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Appliances
{
    public class SteamerMachine : CustomAppliance, IWontRegister
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Steamer Machine");
        public override string UniqueNameID => "steamer_machine";
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateApplianceInfo("Steamer Machine", "A one-trick pony", new()
            {
                new()
                {
                    Title = "<sprite name=\"upgrade\" color=#A8FF1E> Steamy",
                    Description = "Performs only <sprite name=\"steam_0\"> at 225% speed!"
                }
            }, new()))
        };
        public override List<Appliance> Upgrades => new()
        {
            GetCastedGDO<Appliance, BaristaMachine>()
        };
        public override bool IsPurchasableAsUpgrade => true;
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override List<Process> RequiresProcessForShop => new()
        {
            GetCastedGDO<Process, CuplessFillCupProcess>()
        };

        public override List<Appliance.ApplianceProcesses> Processes => new()
        {
            new()
            {
                IsAutomatic = true,
                Process = GetCastedGDO<Process, SteamProcess>(),
                Speed = 2.25f,
                Validity = ProcessValidity.Generic
            }
        };
        public override List<IApplianceProperty> Properties => new()
        {
            new CItemHolder()
        };

        public override void OnRegister(Appliance gdo)
        {
            Prefab.AddComponent<HoldPointContainer>().HoldPoint = Prefab.transform.Find("HoldPoint");

            var counter = Prefab.GetChild("Counter");
            counter.ApplyMaterial("Wood - Default", "Wood 4 - Painted", "Wood 4 - Painted");
            counter.ApplyMaterialToChild("Handle", "Knob");
            counter.ApplyMaterialToChild("Countertop", "Wood - Default");
                
            Prefab.ApplyMaterialToChild("Machine", "Metal- Shiny", "Metal Very Dark", "Metal Black", "Hob Black");
        }
    }
}
