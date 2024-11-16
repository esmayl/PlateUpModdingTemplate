using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace PeePeeMod.GDOs;

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
        // Material material1 = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
        // Material rareMat = MaterialUtils.GetExistingMaterial("Well-done");
        // Texture2D headTexture = Mod.Bundle.LoadAsset<Texture2D>("HeadTexture");
        //
        // material1.name = "HeadMaterial";
        // material1.SetVector("_BaseColor", new Vector4(1,1,1,1));
        // material1.SetFloat("_Smoothness", 0.1f);
        // material1.SetFloat("_Metallic", 0f);
        // material1.SetTexture("_BaseMap",headTexture);
        //
        // for (int i = 0; i <= Prefab.GetChildCount(); i++)
        // {
        //     Prefab.ApplyMaterialToChild("CookedPeePee.00"+i, [rareMat,material1]);
        // }
        
        var cookedPeePee = GameObjectUtils.GetChildObject(Prefab, "CookedPeePee");
        
        var plate = GameObjectUtils.GetChildObject(Prefab, "Plate");
        plate.ApplyMaterial("Plate");
        
        for (int i = 0; i <= cookedPeePee.GetChildCount(); i++)
        {
            cookedPeePee.ApplyMaterialToChild("CookedPeePee.00"+i, "Well-done", "Raw Fish Pink");
        }    
    }

}