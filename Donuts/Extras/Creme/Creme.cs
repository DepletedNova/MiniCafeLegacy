using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Extras
{
    internal class Creme : CustomItem
    {
        public override string UniqueNameID => "creme";
        public override GameObject Prefab => MiniCafe.Main.Bundle.LoadAsset<GameObject>("Creme");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override int SplitCount => 6;
        public override Item SplitSubItem => GetCastedGDO<Item, CremeIngredient>();
        public override bool AllowSplitMerging => true;
        public override bool PreventExplicitSplit => true;
        public override string ColourBlindTag => "Cr";

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChild("Pot", "Metal", "Metal Dark", "Metal Dark");
            Prefab.ApplyMaterialToChild("Creme", "Plastic");
        }
    }
}
