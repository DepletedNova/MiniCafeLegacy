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
    public class HibiscusProvider : CustomAppliance
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Hibiscus Provider");
        public override string UniqueNameID => "hibiscus_provider";
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateApplianceInfo("Hibiscus Plant", "Provides hibiscus flowers", new(), new()))
        };
        public override bool IsPurchasable => true;
        public override PriceTier PriceTier => PriceTier.Cheap;
        public override RarityTier RarityTier => RarityTier.Common;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override bool SellOnlyAsDuplicate => true;

        public override List<IApplianceProperty> Properties => new()
        {
            GetUnlimitedCItemProvider(GetCustomGameDataObject<Hibiscus>().ID),
        };

        public override void OnRegister(Appliance gdo)
        {
            var plant = Prefab.GetChild("plant");
            plant.ApplyMaterialToChild("pot", "Plastic - Red", "Soil");
            plant.ApplyMaterialToChild("trunk", "Wood - Autumn");
            plant.ApplyMaterialToChild("leaf", "Plant  Leafy");
            plant.ApplyMaterialToChild("leaves", "Plant  Leafy");

            Prefab.ApplyMaterialToChildren("flower", "AppleRed", "AppleRed");
        }
    }
}
