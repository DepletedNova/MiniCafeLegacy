using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MiniCafe.Components;
using MiniCafeLegacy.Mains.Tea;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;
using static MiniCafe.Helper;

namespace MiniCafeLegacy.Items
{
    internal class KettleSteeped : CustomItemGroup<KettleSteeped.View>
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public static int KettleID { get; private set; }
        public override void AttachDependentProperties(GameData gameData, GameDataObject gdo)
        {
            base.AttachDependentProperties(gameData, gdo);
            KettleID = gdo.ID;
        }

        public override string UniqueNameID => "kettle_steeped";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Kettle Tea");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override Item DisposesTo => GetCastedGDO<Item, Kettle>();
        public override bool ApplyProcessesToComponents => true;

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
            {
                new()
                {
                    Item = GetCastedGDO<Item, KettleSteeped>(),
                    Text = "St"
                },
                new()
                {
                    Item = GetCastedGDO<Item, SageSteeped>(),
                    Text = "Ma"
                },
                new()
                {
                    Item = GetCastedGDO<Item, EarlGreySteeped>(),
                    Text = "EG"
                },
                new()
                {
                    Item = GetCastedGDO<Item, HibiscusSteeped>(),
                    Text = "Hi"
                },
            };

        public override void OnRegister(ItemGroup gdo)
        {
            var view = Prefab.GetComponent<View>();
            view.Setup(gdo);

            Prefab.ApplyMaterialToChild("pot", "Plastic", "Metal Dark", "Metal", "Hob Black");
            Prefab.ApplyMaterialToChild("lid", "Plastic", "Metal");
            Prefab.GetChild("Steam").ApplyVisualEffect("Steam");

            // Matcha
            Prefab.ApplyMaterialToChild("Matcha", "Sage Tea");

            // Earl Grey
            Prefab.ApplyMaterialToChild("Earl Grey", "Earl Grey Tea");

            // Hibiscus
            Prefab.ApplyMaterialToChild("Hibiscus", "Hibiscus Teapot");
        }

        public override int SplitCount => 6;
        public override float SplitSpeed => 1;
        public override bool PreventExplicitSplit => true;
        public override bool AllowSplitMerging => true;
        public override bool SplitByComponents => true;
        public override Item SplitByComponentsHolder => GetCastedGDO<Item, KettleBoiled>();
        public override Item RefuseSplitWith => GetCastedGDO<Item, KettleBoiled>();

        public override List<IItemProperty> Properties => new()
        {
            new CComponentSplitDepleted()
            {
                DepletionItem = GetCustomGameDataObject<Kettle>().ID
            }
        };

        public class View : AccessedItemGroupView
        {
            protected override List<ComponentGroup> groups => new()
            {
                new()
                {
                    Item = GetCastedGDO<Item, SageSteeped>(),
                    GameObject = gameObject.GetChild("Matcha"),
                },
                new()
                {
                    Item = GetCastedGDO<Item, EarlGreySteeped>(),
                    GameObject = gameObject.GetChild("Earl Grey"),
                },
                new()
                {
                    Item = GetCastedGDO<Item, HibiscusSteeped>(),
                    GameObject = gameObject.GetChild("Hibiscus"),
                },
            };
        }
    }
}
