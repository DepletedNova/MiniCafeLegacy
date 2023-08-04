﻿using IngredientLib.Ingredient.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using MiniCafe.Items;
using MiniCafeLegacy.Processes;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;

namespace MiniCafeLegacy.Mains.Coffee
{
    public class CappuccinoDish : CustomDish
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "cappuccino_dish";
        public override GameObject DisplayPrefab => Main.Bundle.LoadAsset<GameObject>("Big Cappuccino");
        public override GameObject IconPrefab => Main.Bundle.LoadAsset<GameObject>("Big Cappuccino");
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override bool IsUnlockable => true;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
		public override int MinimumFranchiseTier => 0;
		public override bool IsSpecificFranchiseTier => false;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override float SelectionBias => 0;
        public override List<Unlock> HardcodedRequirements => new() { GetCastedGDO<Unlock, EspressoDish>() };
        public override List<Unlock> HardcodedBlockers => new();

        public override Item RequiredDishItem => GetCastedGDO<Item, SmallMug>();
        public override bool RequiredNoDishItem => true;

        public override DishType Type => DishType.Main;
        public override HashSet<Process> RequiredProcesses => new()
        {
            GetCastedGDO<Process, SteamProcess>(),
            GetGDO<Process>(ProcessReferences.FillCoffee),
            GetGDO<Process>(ProcessReferences.FrothMilk),
        };
        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Steam milk in any coffee machine, combine with espresso, add spoon and then serve." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateUnlockInfo("Cappuccino", "Adds cappuccino as a main dish", "Espresso with a few extra steps!"))
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetGDO<Item>(MilkItem),
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, PlatedBigCappuccino>(),
                DynamicMenuType = DynamicMenuType.Static,
                Phase = MenuPhase.Main,
                Weight = 1
            },
            new()
            {
                Item = GetCastedGDO<Item, PlatedSmallCappuccino>(),
                DynamicMenuType = DynamicMenuType.Static,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };

        public override void OnRegister(Dish gdo)
        {
            gdo.Difficulty = 2;
        }
    }
}
