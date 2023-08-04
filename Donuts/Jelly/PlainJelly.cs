using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Mains
{
    internal class PlainJelly : CustomItem
    {
        public override int ID => MiniCafeLegacy.Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "plain_jelly";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Plain Jelly");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChild("donut", "Bread - Inside Cooked");
            Prefab.ApplyMaterialToChild("filling", "Plastic - Light Yellow");
        }
    }
}
