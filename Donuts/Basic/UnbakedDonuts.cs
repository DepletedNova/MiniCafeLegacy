using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;
using static MiniCafe.Helper;

namespace MiniCafeLegacy.Mains
{
    internal class UnbakedDonuts : CustomItem
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "unbaked_donuts";
        public override GameObject Prefab => MiniCafe.Main.Bundle.LoadAsset<GameObject>("Unbaked Donuts");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Chop),
                Duration = 0.6f,
                Result = GetCastedGDO<Item, UnbakedLongJohns>()
            },
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Cook),
                Duration = 2.75f,
                Result = GetCastedGDO<Item, BakedDonuts>()
            }
        };

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChild("Tray", "Metal");
            Prefab.ApplyMaterialToChildren("donut", "Raw Pastry");
        }
    }
}
