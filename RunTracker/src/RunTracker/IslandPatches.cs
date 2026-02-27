using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace RunTracker;

[HarmonyPatch(typeof(RunManager), nameof(RunManager.StartRun))]
class IslandEnterPatch
{

    static void Postfix()
    {
        Character? myCharacter = FindPlayerCharacter();
        if (myCharacter == null) return;
        if (myCharacter.inAirport)
        {
            Plugin.isInAirport?.Invoke();
        }
        else
        {
            Plugin.isInIsland?.Invoke();
        }
    }

    private static Character? FindPlayerCharacter()
    {
        foreach (PhotonView view in UnityEngine.Object.FindObjectsByType<PhotonView>(FindObjectsSortMode.None))
        {
            if (view.IsMine && view.TryGetComponent(out Character character))
            {
                return character;
            }
        }
        return null;
    }
}