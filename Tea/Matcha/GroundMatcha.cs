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
    public class GroundMatcha : CustomItem
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "ground_matcha";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Ground Matcha");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, SageSteeped>(),
                Process = GetGDO<Process>(SteepProcess),
                RequiresWrapper = true
            }
        };

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChild("mortar", "Stone - Black");
            Prefab.ApplyMaterialToChild("pestle", "Stone - Black");
            Prefab.ApplyMaterialToChild("fill", "Sage");
        }
    }
}
