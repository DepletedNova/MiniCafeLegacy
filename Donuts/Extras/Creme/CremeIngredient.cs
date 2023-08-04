using KitchenData;
using KitchenLib.Customs;
using UnityEngine;

namespace MiniCafeLegacy.Extras
{
    internal class CremeIngredient : CustomItem
    {
        public override string UniqueNameID => "creme_ingredient";
        public override GameObject Prefab => MiniCafe.Main.Bundle.LoadAsset<GameObject>("Creme");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
    }
}
