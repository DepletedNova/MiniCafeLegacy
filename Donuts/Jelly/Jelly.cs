using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MiniCafe.Extras;
using MiniCafe.Items;
using MiniCafeLegacy.Extras;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Mains
{
    internal class Jelly : CustomItemGroup<Donut.View>
    {
        public override int ID => MiniCafeLegacy.Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "jelly";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Jelly");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, Caramel>(),
                Text = "Ca"
            },
            new()
            {
                Item = GetCastedGDO<Item, ChocolateGlazeIngredient>(),
                Text = "Ch"
            },
            new()
            {
                Item = GetCastedGDO<Item, GlazeIngredient>(),
                Text = "Gl"
            },
            new()
            {
                Item = GetCastedGDO<Item, SprinklesIngredient>(),
                Text = "Sp"
            },
        };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new()
                {
                    GetCastedGDO<Item, PlainJelly>()
                }
            },
            new()
            {
                Max = 1,
                Min = 0,
                Items = new()
                {
                    GetCastedGDO<Item, SprinklesIngredient>()
                }
            },
            new()
            {
                Max = 1,
                Min = 0,
                Items = new()
                {
                    GetCastedGDO<Item, Caramel>(),
                    GetCastedGDO<Item, ChocolateGlazeIngredient>(),
                    GetCastedGDO<Item, GlazeIngredient>(),
                }
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.TryAddComponent<Donut.View>().Setup(gdo);

            Prefab.ApplyMaterialToChild("Donut", "Bread - Inside Cooked");
            Prefab.ApplyMaterialToChild("Chocolate", "Chocolate");
            Prefab.ApplyMaterialToChild("Caramel", "Caramel");
            Prefab.ApplyMaterialToChild("Glazed", "Bread - Inside");
            Prefab.ApplyMaterialToChild("Creme", "Plastic - Light Yellow");
            Prefab.ApplyMaterialToChild("Sprinkles", "Clothing Pink", "Blueberry", "Plastic - White");
        }
    }
}
