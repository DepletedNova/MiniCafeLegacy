using ApplianceLib.Api;
using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MiniCafe.Extras;
using MiniCafe.Items;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;
using static MiniCafe.Helper;

namespace MiniCafeLegacy.Mains.Tea
{
    internal class PlatedSmallSage : CustomItemGroup<PlatedSmallSage.View>
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "plated_small_sage";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Plated Small Matcha");
        public override Item DisposesTo => GetCastedGDO<Item, SmallMug>();
        public override Item DirtiesTo => GetCastedGDO<Item, SmallMugDirty>();
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.MediumLarge;
        public override bool CanContainSide => true;

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
            {
                new()
                {
                    Item = GetCastedGDO<Item, Teaspoon>(),
                    Text = "SMa"
                },
                new()
                {
                    Item = GetCastedGDO<Item, ChoppedLemon>(),
                    Text = "L"
                },
                new()
                {
                    Item = GetCastedGDO<Item, HoneyIngredient>(),
                    Text = "H"
                },
            };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, SmallSage>(),
                    GetCastedGDO<Item, Teaspoon>()
                },
                IsMandatory = true,
                Min = 2,
                Max = 2,
            },
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, HoneyIngredient>(),
                    GetCastedGDO<Item, ChoppedLemon>()
                },
                RequiresUnlock = true,
                Min = 0,
                Max = 1
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.ApplyGenericPlated();
            Prefab.GetComponent<View>().Setup(gdo);

            SmallMug.ApplyMugMaterials(Prefab.GetChild("Mug"));
            Prefab.ApplyMaterialToChild("Filling", "Sage Tea");

            Prefab.ApplyMaterialToChild("Lemon", "Lemon", "Lemon Inner", "White Fruit");
            Prefab.ApplyMaterialToChild("Honey", "Door Glass", "Honey", "Wood 1");

            RestrictedItemTransfers.AllowItem(MiniCafe.Main.GenericMugKey, gdo);
        }

        internal class View : AccessedItemGroupView
        {

            protected override List<ComponentGroup> groups => new()
            {
                new()
                {
                    Item = GetCastedGDO<Item, ChoppedLemon>(),
                    GameObject = gameObject.GetChild("Lemon")
                },
                new()
                {
                    Item = GetCastedGDO<Item, HoneyIngredient>(),
                    GameObject = gameObject.GetChild("Honey")
                },
            };
        }

    }
}
