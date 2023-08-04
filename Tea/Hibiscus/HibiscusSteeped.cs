using KitchenLib.Customs;
using UnityEngine;

namespace MiniCafeLegacy.Mains.Tea
{
    public class HibiscusSteeped : CustomItem
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "hibiscus_steeped";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Hibiscus");
    }
}
