using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MiniCafeLegacy.Mains.Tea;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.KitchenPropertiesUtils;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Appliances
{
    public class SageProvider : CustomAppliance
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Camellia Sinensis");
        public override string UniqueNameID => "sage_provider";
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateApplianceInfo("Tea Plant", "Provides leaves for matcha", new(), new()))
        };
        public override bool IsPurchasable => true;
        public override PriceTier PriceTier => PriceTier.Cheap;
        public override RarityTier RarityTier => RarityTier.Common;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override bool SellOnlyAsDuplicate => true;

        public override List<IApplianceProperty> Properties => new()
        {
            GetUnlimitedCItemProvider(GetCustomGameDataObject<Sage>().ID),
        };

        public override void OnRegister(Appliance gdo)
        {
            var plant = Prefab.GetChild("plant");
            plant.ApplyMaterialToChild("pot", "Plastic - Dark Green", "Soil");
            plant.ApplyMaterialToChild("stem", "Sage");

            Prefab.ApplyMaterialToChildren("leaf", "Sage");
        }
    }
}
