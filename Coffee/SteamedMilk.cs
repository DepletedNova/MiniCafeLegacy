using ApplianceLib.Api;
using IngredientLib;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using MiniCafe.Extras;
using MiniCafe.Items;
using MiniCafe.Processes;
using MiniCafeLegacy.Processes;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Items
{
    public class SteamedMilk : CustomItem
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "steamed_milk";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Steamed Milk");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Appliance DedicatedProvider => GetGDO<Appliance>(References.GetProvider("Milk"));

        public override void OnRegister(Item gdo)
        {
            var bowl = Prefab.GetChild("bowl");
            bowl.ApplyMaterialToChild("Cylinder.001", "Metal Dark");
            bowl.ApplyMaterialToChild("Cylinder", "Coffee Cup");
            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");
        }
    }
}
