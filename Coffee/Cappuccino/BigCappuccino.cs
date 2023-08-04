using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MiniCafe.Items;
using MiniCafeLegacy.Items;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Mains.Coffee
{
    public class BigCappuccino : CustomItemGroup
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "big_cappuccino";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Big Cappuccino");
        public override Item DisposesTo => GetCastedGDO<Item, BigMug>();
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetGDO<Item>(FrothedMilk),
                Text = "BCa"
            }
        };
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetGDO < Item >(FrothedMilk),
                    GetCastedGDO<Item, BigEspresso>()
                },
                Min = 2,
                Max = 2,
                IsMandatory = true,
            },
        };

        public override void OnRegister(ItemGroup gdo)
        {
            BigMug.ApplyMugMaterials(Prefab.GetChild("mug"));
            Prefab.ApplyMaterialToChild("fill", "Coffee Blend", "Coffee Foam");
            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");
        }
    }
}
