global using static MiniCafe.Helper;
global using static MiniCafe.References;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenMods;
using System.Reflection;
using UnityEngine;

namespace MiniCafeLegacy
{
    public class Main : BaseMod
    {
        public const string GUID = "nova.legacycafe";
        public const string VERSION = "1.0.0";

        public Main() : base(GUID, "Mini Legacy", "Zoey Davis", VERSION, ">=1.0.0", Assembly.GetExecutingAssembly()) { }

        internal static AssetBundle Bundle { get => MiniCafe.Main.Bundle; }

        protected override void OnPostActivate(Mod mod)
        {
            AddGameData();
        }

        public static int GetHash(string UniqueNameID) => StringUtils.GetInt32HashCode($"{MiniCafe.Main.GUID}:{UniqueNameID}");

        internal void AddGameData()
        {
            MethodInfo AddGDOMethod = typeof(BaseMod).GetMethod(nameof(BaseMod.AddGameDataObject));
            int counter = 0;
            Log("Registering GameDataObjects.");
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsAbstract || typeof(IWontRegister).IsAssignableFrom(type))
                    continue;

                if (!typeof(CustomGameDataObject).IsAssignableFrom(type))
                    continue;

                MethodInfo generic = AddGDOMethod.MakeGenericMethod(type);
                generic.Invoke(this, null);
                counter++;
            }
            Log($"Registered {counter} GameDataObjects.");
        }
    }
}
