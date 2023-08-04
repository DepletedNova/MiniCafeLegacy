﻿using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MiniCafe.Items;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;

namespace MiniCafeLegacy.Mains.Coffee
{
    public class BigEspresso : CustomItem
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "big_espresso";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Big Espresso");
        public override Item DisposesTo => GetCastedGDO<Item, BigMug>();
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override string ColourBlindTag => "BEs";

        public override void OnRegister(Item gdo)
        {
            BigMug.ApplyMugMaterials(Prefab.GetChild("mug"));
            Prefab.ApplyMaterialToChild("fill", "Coffee - Black");
            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");
        }
    }
}
