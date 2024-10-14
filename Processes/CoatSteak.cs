using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;

namespace KitchenMyMod.Processes;

class CoatSteak : CustomProcess
{
    // The unique internal name of this process
    public override string UniqueNameID => "CoatSteak";

    // The "default" appliance of this process (e.g., counter for "chop", hob for "cook")
    // When a dish requires this process, this is the appliance that will spawn at the beginning of a run
    public override GameDataObject BasicEnablingAppliance => References.References.Counter;

    // Whether or not the process can be obfuscated, such as through the "Blindfolded Chefs" card. This is normally set to `true`
    public override bool CanObfuscateProgress => true;

    // The localization information for this process. This must be set for at least one language. 
    public override LocalisationObject<ProcessInfo> Info
    {
        get
        {
            var info = new LocalisationObject<ProcessInfo>();

            info.Add(Locale.English, LocalisationUtils.CreateProcessInfo("Coat Steak", "<sprite name=\"coatsteak\">"));

            return info;
        }
    }
}