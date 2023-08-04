﻿using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Mains
{
    internal class BurntLongJohns : CustomItem
    {
        public override int ID => MiniCafeLegacy.Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "burnt_long_johns";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Burnt Long Johns");
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override void OnRegister(Item gdo)
        {
            Prefab.ApplyMaterialToChild("Tray", "Metal");
            Prefab.ApplyMaterialToChildren("donut", "Burned");
        }
    }
}
