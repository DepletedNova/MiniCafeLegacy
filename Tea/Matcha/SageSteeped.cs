using KitchenLib.Customs;
using UnityEngine;

namespace MiniCafeLegacy.Mains.Tea
{
    public class SageSteeped : CustomItem
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "sage_steeped";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Matcha");
    }
}
