using KitchenData;
using KitchenLib.Customs;
using UnityEngine;

namespace PeePeeMod.Cosmetics;

public class PeePeeHat : CustomPlayerCosmetic
{
    public override string UniqueNameID => "PeePeeHat";
    public override CosmeticType CosmeticType => CosmeticType.Outfit;
    public override GameObject Visual => Mod.Bundle.LoadAsset<GameObject>("PeePeeHat");
    public override bool BlockHats => false;
    
    public override void AttachDependentProperties(GameData gameData, GameDataObject gameDataObject)
    {
        base.AttachDependentProperties(gameData, gameDataObject);
    }
}