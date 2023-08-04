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
using static MiniCafe.Helper;

namespace MiniCafeLegacy.Mains
{
    internal class Donut : CustomItemGroup<Donut.View>
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "donut";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Donut");
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
                    GetCastedGDO<Item, PlainDonut>()
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
            Prefab.TryAddComponent<View>().Setup(gdo);

            Prefab.ApplyMaterialToChild("Donut", "Bread - Inside Cooked");
            Prefab.ApplyMaterialToChild("Chocolate", "Chocolate");
            Prefab.ApplyMaterialToChild("Caramel", "Caramel");
            Prefab.ApplyMaterialToChild("Glazed", "Bread - Inside");
            Prefab.ApplyMaterialToChild("Sprinkles", "Clothing Pink", "Blueberry", "Plastic - White");
        }

        public class View : AccessedItemGroupView
        {
            protected override List<ComponentGroup> groups => new()
            {
                new()
                {
                    Item = GetCastedGDO<Item, SprinklesIngredient>(),
                    GameObject = gameObject.GetChild("Sprinkles")
                },
                new()
                {
                    Item = GetCastedGDO<Item, Caramel>(),
                    GameObject = gameObject.GetChild("Caramel")
                },
                new()
                {
                    Item = GetCastedGDO<Item, ChocolateGlazeIngredient>(),
                    GameObject = gameObject.GetChild("Chocolate")
                },
                new()
                {
                    Item = GetCastedGDO<Item, GlazeIngredient>(),
                    GameObject = gameObject.GetChild("Glazed")
                },
            };
        }
    }
}
