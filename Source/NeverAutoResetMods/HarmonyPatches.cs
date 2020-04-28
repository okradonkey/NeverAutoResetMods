using Verse;
using HarmonyLib;


// The property getter for resetModsConfigOnCrash will always return false.
// "Auto-reset mods config on crash" will always appear to be disabled (even if the internal bool is true).

namespace NeverAutoResetMods
{
    [StaticConstructorOnStartup]
    internal static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            Harmony harmonyInstance = new Harmony(id: "RimWorld.OkraDonkey.NeverAutoResetMods.main");

            harmonyInstance.Patch(AccessTools.PropertyGetter(typeof(Prefs), "ResetModsConfigOnCrash"),
                postfix: new HarmonyMethod(typeof(HarmonyPatches), nameof(ResetModsGetter)));
        }
        private static void ResetModsGetter(ref bool __result)
        {
            __result = false;
        }
    }
}
