using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenMyMod.GDOs;

public class UncookedSpecialSteak : CustomItemGroup<CoatedSteakItemGroupView>
{
    public override string UniqueNameID => "Special Steak";
    public override GameObject Prefab => References.References.CrackedEgg.Prefab;
    public override ItemCategory ItemCategory => ItemCategory.Generic;
    public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
    public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
    {
        new ItemGroup.ItemSet()
        {
            Max = 1,
            Min = 1,
            IsMandatory = true,
            Items = new List<Item>()
            {
                References.References.Beef
            }
        },
        new ItemGroup.ItemSet()
        {
            Max = 1,
            Min = 1,
            IsMandatory = true,
            Items = new List<Item>()
            {
                References.References.Egg
            }
        }
    };

    public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>()
    {
        new Item.ItemProcess
        {
            Duration = 0.1f,
            Process = References.References.Cook,
            Result = References.References.CookedSpecialSteak
        }
    };


    public override void OnRegister(GameDataObject gameDataObject)
    {
        base.OnRegister(gameDataObject);
    }
}


public class CoatedSteakItemGroupView : ItemGroupView
{
    internal void Setup(GameObject prefab)
    {
        // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
        // All of these sub-objects are hidden unless the item is present
        // ComponentGroups = new()
        // {
        //     new()
        //     {
        //         GameObject = GameObjectUtils.GetChildObject(prefab, "mushroomHalf.017"),
        //         Item = References.References.Beef
        //     },
        //     new()
        //     {
        //         GameObject = GameObjectUtils.GetChildObject(prefab, "Onion - Chopped.008"),
        //         Item = References.References.Egg
        //     }
        // };

        ComponentLabels = new()
        {
            new()
            {
                Item = References.References.Beef,
                Text = "Mu"
            },
            new()
            {
                Item = References.References.Egg,
                Text = "O"
            }
        };
    }
}