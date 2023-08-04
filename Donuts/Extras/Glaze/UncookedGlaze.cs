﻿using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;
using static MiniCafe.Helper;

namespace MiniCafeLegacy.Extras
{
    internal class UncookedGlaze : CustomItemGroup<UncookedGlaze.View>
    {
        public override string UniqueNameID => "uncooked_glaze";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Uncooked Glaze");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Duration = 6.5f,
                Process = GetGDO<Process>(ProcessReferences.Cook),
                Result = GetCastedGDO<Item, Glaze>()
            }
        };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Pot),
                    GetGDO<Item>(MilkItem),
                }
            },
            new()
            {
                Max = 1,
                Min = 1,
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Sugar)
                }
            },
            new()
            {
                Max = 1,
                Min = 1,
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Sugar)
                }
            },
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.GetComponent<View>().Setup(gdo);

            Prefab.ApplyMaterialToChild("Pot", "Metal");
            Prefab.ApplyMaterialToChild("Handles", "Metal Dark");
            Prefab.ApplyMaterialToChild("Milk", "Plastic - White");
            Prefab.ApplyMaterialToChildren("Sugar", "Sugar");
        }

        internal class View : AccessedItemGroupView
        {
            protected override List<ComponentGroup> groups => new()
            {
                new()
                {
                    Item = GetGDO<Item>(ItemReferences.Sugar),
                    Objects = new()
                    {
                        gameObject.GetChild("Sugar 1"),
                        gameObject.GetChild("Sugar 2"),
                    }
                }
            };
        }
    }
}
