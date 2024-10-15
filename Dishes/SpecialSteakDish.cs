using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenMyMod.Dishes;

class SpecialSteakDish : CustomDish
{
    public override string UniqueNameID => "SpecialSteakDish";
    public override DishType Type => DishType.Main;

    public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("PlatedPeePee");
    public override GameObject IconPrefab => Mod.Bundle.LoadAsset<GameObject>("PlatedPeePee");
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
    public override HashSet<Dish> PrerequisiteDishesEditor => new HashSet<Dish>();
    public override List<string> StartingNameSet => new List<string>
    {
        "Steak a'lot",
    };

    public override HashSet<Item> MinimumIngredients => new HashSet<Item>
    {
        References.References.Egg,
        References.References.Beef,
        References.References.Plate
    };
    public override HashSet<Process> RequiredProcesses => new HashSet<Process>
    {
        References.References.Cook,
        References.References.Knead
    };
    
    public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
    {
        new Dish.MenuItem
        {
            Item = References.References.CookedSpecialSteak,
            Phase = MenuPhase.Main,
            Weight = 1
        }
    };
    
    public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
    {
        { Locale.English, "Combine your butt and cracked egg together. Cook and eat! yumyumyumyumyum" },
    };
    public override List<(Locale, UnlockInfo)> InfoList => new()
    {
        ( Locale.English, LocalisationUtils.CreateUnlockInfo("Special Steak menu", "Adds special steak to the menu", "You don't wanna know how it ended on your plate...") )
    };

    public override void OnRegister(GameDataObject gameDataObject)
    {
        var cookedPeePee = GameObjectUtils.GetChildObject(DisplayPrefab, "CookedPeePee");
        var plate = GameObjectUtils.GetChildObject(DisplayPrefab, "Plate");
        plate.ApplyMaterial("Plate");
        
        for (int i = 0; i <= 4; i++)
        {
            cookedPeePee.ApplyMaterialToChild("CookedPeePee.00"+i, "Metal Dark", "Raw Fish Pink");
        }    
    }
}