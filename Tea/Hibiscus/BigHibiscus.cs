using ApplianceLib.Api;
using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MiniCafe.Items;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Mains.Tea
{
    internal class BigHibiscus : CustomItemGroup
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "big_hibiscus";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Big Hibiscus");
        public override Item DisposesTo => GetCastedGDO<Item, BigMug>();
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override bool AutoCollapsing => true;

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, BigHibiscus>(),
                Text = "BHi"
            }
        };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, BigMug>(),
                    GetCastedGDO<Item, HibiscusSteeped>(),
                    GetCastedGDO<Item, BoiledWater>(),
                },
                IsMandatory = true,
                Min = 3,
                Max = 3,
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            BigMug.ApplyMugMaterials(Prefab.GetChild("mug"));
            Prefab.ApplyMaterialToChild("fill", "Hibiscus Tea");
            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");

            Prefab.ApplyMaterialToChild("Lemon", "Lemon", "Lemon Inner", "White Fruit");
            Prefab.ApplyMaterialToChild("Honey", "Honey");

            RestrictedItemTransfers.AllowItem(MiniCafe.Main.GenericMugKey, gdo);
        }
    }
}
