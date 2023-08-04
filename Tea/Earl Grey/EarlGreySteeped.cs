using KitchenLib.Customs;
using UnityEngine;

namespace MiniCafeLegacy.Mains.Tea
{
    public class EarlGreySteeped : CustomItem
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "earl_grey_steeped";
        public override GameObject Prefab => Main.Bundle.LoadAsset<GameObject>("Earl Grey");
    }
}
