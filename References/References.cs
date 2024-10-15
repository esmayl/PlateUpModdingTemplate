using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMyMod.GDOs;
using KitchenMyMod.Processes;

namespace KitchenMyMod.References;

public class References
{
    public static Item Beef => Find<Item>(ItemReferences.Meat);
    public static Item Egg => Find<Item>(ItemReferences.Egg);
    public static Item CrackedEgg => Find<Item>(ItemReferences.EggCracked);
    public static Item Burned => Find<Item>(ItemReferences.BurnedFood);
    public static Item BurnedBread => Find<Item>(ItemReferences.BurnedBread);

    
    public static Item CookedSpecialSteak => Find<Item, CookedSpecialSteak>();
    public static Item PlatedSpecialSteak => Find<Item, PlatedSpecialSteak>();
    
    public static Appliance Counter => Find<Appliance>(ApplianceReferences.Countertop);

    public static Process Cook => Find<Process>(ProcessReferences.Cook);
    public static Process Chop => Find<Process>(ProcessReferences.Chop);
    public static Process Knead => Find<Process>(ProcessReferences.Knead);
    public static Process Oven => Find<Process>(ProcessReferences.RequireOven);
    
    public static Item Plate => Find<Item>(ItemReferences.Plate);
    public static Item DirtyPlate => Find<Item>(ItemReferences.PlateDirty);
    
    internal static T Find<T>(int id) where T : GameDataObject
    {
        return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
    }
    
    internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
    {
        return GDOUtils.GetCastedGDO<T, C>();
    }
}