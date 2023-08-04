﻿using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MiniCafe.Items;
using MiniCafeLegacy.Mains.Coffee;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Desserts
{
    internal class SmallMocha : CustomItemGroup<SmallMocha.View>
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "small_mocha";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Small Mocha");
        public override Item DisposesTo => GetCastedGDO<Item, SmallMug>();
        public override Item DirtiesTo => GetCastedGDO<Item, SmallMugDirty>();
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.MediumLarge;

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, ChocolateSauce>(),
                Text = "SMo"
            }
        };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, SmallCappuccino>(),
                    GetCastedGDO<Item, ChocolateSauce>()
                },
                Min = 2,
                Max = 2,
                IsMandatory = true,
            },
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, WhippedCream>()
                },
                Max = 1,
                Min = 1,
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.GetComponent<View>().Setup(gdo);

            SmallMug.ApplyMugMaterials(Prefab.GetChild("mug"));
            Prefab.ApplyMaterialToChild("fill", "Coffee Blend", "Chocolate");

            var cream = Prefab.GetChild("cream");
            cream.ApplyMaterial("Coffee Cup");
            cream.ApplyMaterialToChild("chocolate", "Chocolate");

            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");
        }

        internal class View : AccessedItemGroupView
        {
            protected override List<ComponentGroup> groups => new()
            {
                new()
                {
                    Item = GetCastedGDO<Item, WhippedCream>(),
                    GameObject = gameObject.GetChild("cream")
                }
            };
        }
    }
}
