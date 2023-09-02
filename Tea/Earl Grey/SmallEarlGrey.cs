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
    internal class SmallEarlGrey : CustomItemGroup
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "small_earl_grey";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Small Earl Grey");
        public override Item DisposesTo => GetCastedGDO<Item, SmallMug>();
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override bool AutoCollapsing => true;

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, SmallEarlGrey>(),
                Text = "SEG"
            }
        };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, SmallMug>(),
                    GetCastedGDO<Item, EarlGreySteeped>(),
                    GetCastedGDO<Item, BoiledWater>(),
                },
                IsMandatory = true,
                Min = 3, Max = 3,
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            SmallMug.ApplyMugMaterials(Prefab.GetChild("mug"));
            Prefab.ApplyMaterialToChild("fill", "Earl Grey Tea");
            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");

            Prefab.ApplyMaterialToChild("Lemon", "Lemon", "Lemon Inner", "White Fruit");
            Prefab.ApplyMaterialToChild("Honey", "Honey");

            RestrictedItemTransfers.AllowItem(MiniCafe.Main.GenericMugKey, gdo);
        }
    }
}
