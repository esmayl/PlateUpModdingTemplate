using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenMyMod.Dishes
{

    class NewDishDish : CustomDish
    {
        public override string UniqueNameID => "NewDishDish";
        public override DishType Type => DishType.Main;

        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("NewDish");
        public override GameObject IconPrefab => Mod.Bundle.LoadAsset<GameObject>("NewDish");
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;

        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool IsMainThatDoesNotNeedPlates => true;
        public override int Difficulty => 5;

        public override List<string> StartingNameSet => new List<string>
        {
            "Restaurant NewDish",
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            // References.References.Egg,
            // References.References.Beef,
            // References.References.Plate
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            // References.References.Cook,
            // References.References.Knead
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                // Item = References.References.Egg,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Description here!" },
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>()
        {
            (Locale.English, LocalisationUtils.CreateUnlockInfo("NewDish", "Adds NewDish to the menu", "Flavour text here!"))
        };
    }
}