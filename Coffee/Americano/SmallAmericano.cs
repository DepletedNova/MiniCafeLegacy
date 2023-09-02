using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using MiniCafe.Items;
using System.Collections.Generic;
using UnityEngine;
using IngredientLib.Ingredient.Items;
using static KitchenLib.Utils.GDOUtils;

namespace MiniCafeLegacy.Mains.Coffee
{
    public class SmallAmericano : CustomItemGroup
    {
        public override string UniqueNameID => "small_americano";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Small Americano");
        public override Item DisposesTo => GetCastedGDO<Item, SmallMug>();
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetCastedGDO < Item, BoiledWater >(),
                Text = "SAm"
            }
        };
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, SmallEspresso>(),
                    GetCastedGDO < Item, BoiledWater >()

                },
                Min = 2,
                Max = 2,
                IsMandatory = true,
                OrderingOnly = false,
                RequiresUnlock = false,
            },
        };

        public override void OnRegister(ItemGroup gdo)
        {
            SmallMug.ApplyMugMaterials(Prefab.GetChild("mug"));
            Prefab.ApplyMaterialToChild("fill", "Americano", "Coffee - Black");
            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");
            Prefab.ApplyMaterialToChild("Straw", "Plastic - Red", "Plastic - Red");
        }
    }
}
