using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenMyMod.GDOs;

public class CookedSpecialSteak : CustomItem
{
    public override string UniqueNameID => "CookedSpecialSteak";
    public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("CookedPeePee");
    public override ItemCategory ItemCategory => ItemCategory.Generic;
    public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
    public override ItemValue ItemValue => ItemValue.ExtraLarge;
    
    public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
    {
        new Item.ItemProcess
        {
            Duration = 3,
            Process = References.References.Cook,
            IsBad = true,
            Result = References.References.Burned
        }
    };
    
    public override void OnRegister(GameDataObject gameDataObject)
    {
        for (int i = 0; i <= Prefab.GetChildCount(); i++)
        {
            Prefab.ApplyMaterialToChild("CookedPeePee.00"+i, "Well-done","Raw Fish Pink");
        }
    }

}