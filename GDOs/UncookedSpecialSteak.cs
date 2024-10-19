using System.Collections.Generic;
using System.Linq;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenMyMod.GDOs;

public class UncookedSpecialSteak : CustomItemGroup<UncookedSteakItemGroupView>
{
    public override string UniqueNameID => "UncookedSpecialSteak";
    public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("PeePeeParent");
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
        Prefab.ApplyMaterialToChild("PeePee", "Raw Fish Pink", "Rare");
    }
}


public class UncookedSteakItemGroupView : ItemGroupView
{
    internal void Setup(GameObject prefab)
    {
        ComponentGroups = new()
        {
            new()
            {
                GameObject = GameObjectUtils.GetChildObject(prefab, "PeePee"),
                Item = References.References.UncookedSpecialSteak
            },
        };

        ComponentLabels = new()
        {
            new()
            {
                Item = References.References.UncookedSpecialSteak,
                Text = "PP"
            }
        };
    }
}