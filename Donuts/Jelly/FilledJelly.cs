using IngredientLib.Ingredient.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Mains
{
    internal class FilledJelly : CustomItemGroup
    {
        public override int ID => MiniCafeLegacy.Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "filled_jelly";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Filled Jelly");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override int SplitCount => 2;
        public override Item SplitSubItem => GetCastedGDO<Item, PlainJelly>();
        public override List<Item> SplitDepletedItems => new() { GetCastedGDO<Item, PlainJelly>() };
        public override float SplitSpeed => 1.5f;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, BakedJelly>(),
                    GetCastedGDO<Item, Custard>()
                },
                Max = 2,
                Min = 2
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.ApplyMaterialToChild("Tray", "Metal");

            gdo.AddObjectsSplittableView(Prefab, "donut", "Bread - Inside Cooked");

            for (int i = 0; i < Prefab.GetChildCount(); i++)
                if (Prefab.GetChild(i).name.Contains("donut"))
                    Prefab.GetChild(i).ApplyMaterialToChild("filling", "Plastic - Light Yellow");
        }
    }
}
