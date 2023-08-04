using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;
using static MiniCafe.Helper;

namespace MiniCafeLegacy.Extras
{
    internal class Glaze : CustomItem
    {
        public override string UniqueNameID => "cooked_glaze";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Glaze");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override int SplitCount => 15;
        public override Item SplitSubItem => GetCastedGDO<Item, GlazeIngredient>();
        public override List<Item> SplitDepletedItems => new() { GetGDO<Item>(ItemReferences.Pot) };
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);
        public override bool AllowSplitMerging => true;
        public override bool PreventExplicitSplit => true;
        public override string ColourBlindTag => "Gl";

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChild("Pot", "Metal");
            Prefab.ApplyMaterialToChild("Handles", "Metal Dark");
            Prefab.ApplyMaterialToChild("Glaze", "Bread - Inside");

            Prefab.AddPositionSplittableView(new() { Prefab.GetChild("Glaze") }, Vector3.up * 0.05f, Vector3.up * 0.275f);
        }
    }
}
