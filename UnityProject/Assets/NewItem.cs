using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenMyMod.GDOs
{

    public class NewItem : CustomItem
    {
        public override string UniqueNameID => "NewItem";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("NewItem");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.ExtraLarge;
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            // new Item.ItemProcess
            // {
            //     Duration = 3,
            //     Process = References.References.Cook,
            //     IsBad = true,
            //     Result = References.References.Burned
            // }
        };

        
        #pragma warning disable CS0672
        
        /// <summary>
        /// Use this to setup material of the Prefab
        /// </summary>
        /// <returns></returns>
        public override void OnRegister(GameDataObject gameDataObject)
        {
            // Prefab.ApplyMaterialToChild("ChildName", "Well-done","Raw Fish Pink");
        }
        #pragma warning restore CS0672
    }
}