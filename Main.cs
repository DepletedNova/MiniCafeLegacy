global using static MiniCafe.Helper;
global using static MiniCafe.References;
global using static KitchenLib.Utils.GDOUtils;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Event;
using KitchenLib.Utils;
using KitchenMods;
using System.Reflection;
using UnityEngine;
using KitchenData;
using MiniCafe.Items;
using KitchenLib.References;
using MiniCafeLegacy.Mains.Coffee;

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

            Events.BuildGameDataEvent += (s, args) =>
            {
                UpdateMugs();

                args.gamedata.ProcessesView.Initialise(args.gamedata);
            };
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

        #region Update Mini Cafe
        private void UpdateMugs()
        {
            GetCastedGDO<Item, BigMug>().DerivedProcesses.Add(new()
            {
                Duration = 3.5f,
                Process = GetGDO<Process>(ProcessReferences.FillCoffee),
                Result = GetCastedGDO<Item, BigEspresso>()
            });
            GetCastedGDO<Item, SmallMug>().DerivedProcesses.Add(new()
            {
                Duration = 2.75f,
                Process = GetGDO<Process>(ProcessReferences.FillCoffee),
                Result = GetCastedGDO<Item, SmallEspresso>()
            });
        }
        #endregion
    }
}
