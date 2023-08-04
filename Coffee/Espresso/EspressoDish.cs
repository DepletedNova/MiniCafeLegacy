﻿using IngredientLib.Util;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MiniCafe.Extras;
using MiniCafe.Items;
using MiniCafe.Processes;
using MiniCafeLegacy.Processes;
using System.Collections.Generic;
using UnityEngine;
using static KitchenLib.Utils.GDOUtils;
using static KitchenLib.Utils.MaterialUtils;

namespace MiniCafeLegacy.Mains.Coffee
{
    public class EspressoDish : CustomDish
    {
        public override int ID => Main.GetHash(UniqueNameID);
        public override string UniqueNameID => "espresso_dish";
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override bool IsUnlockable => true;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallIncrease;
        public override int MinimumFranchiseTier => 0;
        public override bool IsSpecificFranchiseTier => false;
        public override float SelectionBias => 0;

        public override Item RequiredDishItem => GetCastedGDO<Item, SmallMug>();
        public override bool RequiredNoDishItem => true;

        public override GameObject IconPrefab => Main.Bundle.LoadAsset<GameObject>("Coffee Icon");
        public override GameObject DisplayPrefab => Main.Bundle.LoadAsset<GameObject>("Plated Big Espresso");
        public override DishType Type => DishType.Base;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool DestroyAfterModUninstall => false;
        public override HashSet<Process> RequiredProcesses => new()
        {
            GetCastedGDO<Process, CuplessFillCupProcess>(),
            GetCastedGDO<Process, RequiresMugProcess>()
        };
        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Take mug, fill with coffee, add spoon and then serve. Interact with the mug container to swap between mug types." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateUnlockInfo("Coffee", "Adds espresso as a main dish", "That's a weird main course!"))
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetCastedGDO<Item, Teaspoon>(),
        };
        public override List<string> StartingNameSet => new()
        {
            "Deja Brew",
            "The Big Bean",
            "Mocha Madness",
            "Queen of Beans",
            "Java the Hutt",
            "Espress Yourself",
            "The Polar Espresso",
            "Rise and Grind",
            "Hugs with Mugs",
            "The Rancid Spoon",
            "Bean There, Sipped That",
            "Depresso Espresso"
        };
        //public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => ExtraHelper.GetUnlocks(GetCastedGDO<Item, Teaspoon>());
        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, PlatedBigEspresso>(),
                DynamicMenuType = DynamicMenuType.Static,
                Phase = MenuPhase.Main,
                Weight = 1
            },
            new()
            {
                Item = GetCastedGDO<Item, PlatedSmallEspresso>(),
                DynamicMenuType = DynamicMenuType.Static,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };

        public override void OnRegister(Dish gdo)
        {
            IconPrefab.ApplyMaterialToChild("Croissant", "Croissant");
            IconPrefab.ApplyMaterialToChild("Fill", "Americano", "Coffee - Black");
            IconPrefab.ApplyMaterialToChild("Plate", "Marble", "Plate - Ring");
            BigMug.ApplyMugMaterials(IconPrefab.GetChild("Mug"));

            gdo.Difficulty = 2;
        }
    }
}
