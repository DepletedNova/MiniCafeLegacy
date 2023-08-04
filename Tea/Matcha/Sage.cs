using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using MiniCafe.Appliances;
using MiniCafeLegacy.Appliances;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;
using static MiniCafe.Helper;

namespace MiniCafeLegacy.Mains.Tea
{
    public class Sage : CustomItem
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "sage";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Matcha");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Appliance DedicatedProvider => GetCastedGDO<Appliance, SageProvider>();

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, GroundMatcha>(),
                Process = GetGDO<Process>(ProcessReferences.Chop),
                Duration = 0.5f
            }
        };

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChildren("leaf", "Sage");
        }
    }
}
