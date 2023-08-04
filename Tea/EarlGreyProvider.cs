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
    public class EarlGreyProvider : CustomAppliance
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Earl Grey Provider");
        public override string UniqueNameID => "earl_grey_provider";
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateApplianceInfo("Earl Grey Blend", "Provides earl grey", new(), new()))
        };
        public override bool IsPurchasable => true;
        public override PriceTier PriceTier => PriceTier.Cheap;
        public override RarityTier RarityTier => RarityTier.Common;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override bool SellOnlyAsDuplicate => true;

        public override List<IApplianceProperty> Properties => new()
        {
            GetUnlimitedCItemProvider(GetCustomGameDataObject<EarlGrey>().ID),
        };

        public override void OnRegister(Appliance gdo)
        {
            // Materials
            GameObject parent = Prefab.GetChild("Block/Counter2");
            var paintedWood = GetMaterialArray("Wood 4 - Painted");
            var defaultWood = GetMaterialArray("Wood - Default");
            parent.ApplyMaterialToChild("Counter", paintedWood);
            parent.ApplyMaterialToChild("Counter Doors", paintedWood);
            parent.ApplyMaterialToChild("Counter Surface", defaultWood);
            parent.ApplyMaterialToChild("Counter Top", defaultWood);
            parent.ApplyMaterialToChild("Handles", "Knob");

            var container = Prefab.GetChild("Container");
            container.ApplyMaterial("Wood 1");
            container.ApplyMaterialToChildren("Teabag", "Cloth - Fancy", "Earl Grey Tea");

            Prefab.ApplyMaterialToChild("Napkin", "Paper", "Earl Grey Tea");
        }
    }
}
