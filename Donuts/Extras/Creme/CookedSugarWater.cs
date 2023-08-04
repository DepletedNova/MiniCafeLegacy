using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Extras
{
    internal class CookedSugarWater : CustomItem
    {
        public override string UniqueNameID => "sugar_water";
        public override GameObject Prefab => MiniCafe.Main.Bundle.LoadAsset<GameObject>("Cooked Sugar Water");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChild("Pot", "Metal", "Metal Dark", "Metal Dark");
            Prefab.ApplyMaterialToChild("Water", "Soup - Watery");
        }
    }
}
