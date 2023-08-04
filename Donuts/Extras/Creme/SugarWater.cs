using KitchenData;
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
    internal class SugarWater : CustomItemGroup
    {
        public override string UniqueNameID => "uncooked_sugar_water";
        public override GameObject Prefab => MiniCafe.Main.Bundle.LoadAsset<GameObject>("Sugar Water");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Duration = 4f,
                Process = GetGDO<Process>(ProcessReferences.Cook),
                Result = GetCastedGDO<Item, CookedSugarWater>()
            }
        };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Max = 2,
                Min = 2,
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Water),
                    GetGDO<Item>(ItemReferences.Sugar)
                }
            },
        };

        public override void OnRegister(ItemGroup gdo)
        {
            Prefab.ApplyMaterialToChild("Pot", "Metal", "Metal Dark", "Metal Dark");
            Prefab.ApplyMaterialToChild("Water", "Water");
            Prefab.ApplyMaterialToChild("Sugar", "Sugar");
        }
    }
}
