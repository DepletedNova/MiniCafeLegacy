using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MiniCafe.Items;
using MiniCafeLegacy.Items;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;

namespace MiniCafeLegacy.Mains.Coffee
{
    public class SmallCappuccino : CustomItemGroup
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "small_cappuccino";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Small Cappuccino");
        public override Item DisposesTo => GetCastedGDO<Item, SmallMug>();
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetGDO<Item>(FrothedMilk),
                Text = "SCa"
            }
        };
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(FrothedMilk),
                    GetCastedGDO<Item, SmallEspresso>()
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
            Prefab.ApplyMaterialToChild("fill", "Coffee Blend", "Coffee Foam");
            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");
        }
    }
}
