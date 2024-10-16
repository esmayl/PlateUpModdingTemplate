using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenMyMod.GDOs;

public class PlatedSpecialSteak : CustomItemGroup<PlatedSpecialSteakItemGroupView>
{
    public override string UniqueNameID => "PlatedSpecialSteak";
    public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("PlatedPeePee");
    public override ItemCategory ItemCategory => ItemCategory.Generic;
    public override ItemStorage ItemStorageFlags => ItemStorage.None;
    public override ItemValue ItemValue => ItemValue.Large;
    public override Item DisposesTo => References.References.Plate;
    public override Item DirtiesTo =>  References.References.DirtyPlate;
    public override bool CanContainSide => true;
    public override bool IsConsumedByCustomer => true;

    public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
    {
        new ItemGroup.ItemSet()
        {
            Max = 1,
            Min = 1,
            IsMandatory = true,
            Items = new List<Item>()
            {
                References.References.Plate
            }
        },
        new ItemGroup.ItemSet()
        {
            Max = 1,
            Min = 1,
            IsMandatory = true,
            Items = new List<Item>()
            {
                References.References.CookedSpecialSteak
            }
        }
    };
    
    public override void OnRegister(GameDataObject gameDataObject)
    {
        var cookedPeePee = GameObjectUtils.GetChildObject(Prefab, "CookedPeePee");
        var plate = GameObjectUtils.GetChildObject(Prefab, "Plate");
        plate.ApplyMaterial("Plate");
        
        for (int i = 0; i <= cookedPeePee.GetChildCount(); i++)
        {
            cookedPeePee.ApplyMaterialToChild("CookedPeePee.00"+i, "Well-done", "Raw Fish Pink");
        }    
    }
}

public class PlatedSpecialSteakItemGroupView : ItemGroupView
{
    internal void Setup(GameObject prefab)
    {
        ComponentGroups = new()
        {
            new()
            {
                GameObject = GameObjectUtils.GetChildObject(prefab, "Plate"),
                Item = References.References.Plate
            },
            new ()
            {
                GameObject = GameObjectUtils.GetChildObject(prefab,"CookedPeePee"),
                Item = References.References.CookedSpecialSteak
            }
        };


        ComponentLabels = new()
        {
            new()
            {
                Text = "Pl",
                Item = References.References.Plate
            },
            new ()
            {
                Text = "CoSpSt",
                Item = References.References.CookedSpecialSteak
            },
        };
    }
}