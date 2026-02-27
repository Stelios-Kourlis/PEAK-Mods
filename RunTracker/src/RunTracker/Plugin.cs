using System;
using BepInEx;
using HarmonyLib;

namespace RunTracker;

[BepInAutoPlugin]
public partial class Plugin : BaseUnityPlugin
{
    public static Action isInAirport = null!;
    public static Action isInIsland = null!;

    private void Awake()
    {
        Harmony _harmony = new("com.github.Stelios-Kourlis.RunTracker");
        _harmony.PatchAll();
    }
}
