using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Mains
{
    internal class PlainDonut : CustomItem
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "plain_donut";
        public override GameObject Prefab => MiniCafe.Main.Bundle.LoadAsset<GameObject>("Plain Donut");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChild("donut", "Bread - Inside Cooked");
        }
    }
}
