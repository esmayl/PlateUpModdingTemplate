using System.Collections.Generic;
using System.Linq;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace PeePeeMod.GDOs;

public class UncookedSpecialSteak : CustomItemGroup<UncookedSteakItemGroupView>
{
    public override string UniqueNameID => "UncookedSpecialSteak";
    public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("PeePeeParent2");
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
        var mats = MaterialUtils.GetAllMaterials(true);
        foreach (Material mat in mats)
        {
            Mod.LogInfo(mat.shader.name);
        }

        Material material1 = new Material(Shader.Find("Universal Render Pipeline/Unlit"));

        material1.name = "HeadMaterial";
        material1.SetVector("_BaseColor", new Vector4(1,1,1,1));
        material1.SetFloat("_Smoothness", 0.1f);
        material1.SetFloat("_Metallic", 0f);
        
        Material rareMat = MaterialUtils.GetExistingMaterial("Rare");
        Texture2D headTexture = Mod.Bundle.LoadAsset<Texture2D>("HeadTexture");
        // Material newMat = UnityEngine.Object.Instantiate(headMat);
        // newMat.mainTexture = headTexture;
        //
        material1.SetTexture("_BaseMap",headTexture);

        Prefab.ApplyMaterialToChild("PeePee2", [material1,rareMat]);
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