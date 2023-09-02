﻿using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using MiniCafe.Views;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static MiniCafe.Helper;

namespace MiniCafeLegacy.Items
{
    internal class KettleFilled : CustomItemGroup<KettleFilled.View>
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public static int KettleID { get; private set; }
        public override void AttachDependentProperties(GameData gameData, GameDataObject gdo)
        {
            base.AttachDependentProperties(gameData, gdo);
            KettleID = gdo.ID;
        }

        public override string UniqueNameID => "kettle_filled";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Kettle");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override Item DisposesTo => GetCastedGDO<Item, Kettle>();

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, KettleBoiled>(),
                Process = GetGDO<Process>(ProcessReferences.Cook),
                Duration = 4.5f
            }
        };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, Kettle>()
                },
                IsMandatory = true,
                Max = 1,
                Min = 1,
            },
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Water)
                },
                Max = 1,
                Min = 1
            }
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.GetComponent<View>().Setup(gdo);

            Prefab.TryAddComponent<ItemProcessView>().Objects = new()
            {
                Prefab.GetChild("lid")
            };
        }

        public class View : AccessedItemGroupView
        {
            protected override List<ComponentGroup> groups => new()
            {
                new()
                {
                    GameObject = gameObject.GetChild("water"),
                    Item = GetGDO<Item>(ItemReferences.Water)
                }
            };
        }
    }
}
