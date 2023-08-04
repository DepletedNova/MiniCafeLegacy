using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;
using static MiniCafe.Helper;

namespace MiniCafeLegacy.Mains.Tea
{
    public class GroundHibiscus : CustomItem
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "ground_hibiscus";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Ground Hibiscus");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, HibiscusSteeped>(),
                Process = GetGDO<Process>(SteepProcess),
                RequiresWrapper = true
            }
        };

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChild("mortar", "Stone - Black");
            Prefab.ApplyMaterialToChild("pestle", "Stone - Black");
            Prefab.ApplyMaterialToChild("fill", "Hibiscus Tea");
        }
    }
}
