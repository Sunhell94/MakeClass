using Vintagestory.API.Common;
using System.Collections.Generic;
using HarmonyLib;

namespace MakeClass.Internal;

[HarmonyPatch(
    typeof(PlayerAnimationManager),
    nameof(PlayerAnimationManager.StartAnimation),
    typeof(AnimationMetaData)
)]
public class SmithAnimPatch
{
    private static readonly HashSet<string> SmithingAnimCodes = new HashSet<string>
    {
        "smithing", "smithing-fp", "smithingwide", "smithingwide-fp"
    };

    static void Prefix(PlayerAnimationManager __instance, AnimationMetaData animdata)
    {
        if (animdata == null || !SmithingAnimCodes.Contains(animdata.Code)) return;

        var eplr = AccessTools
            .Field(typeof(PlayerAnimationManager), "plrEntity")
            .GetValue(__instance);
        if (eplr is not EntityPlayer playerEntity) return;

        var playerClass = playerEntity.WatchedAttributes["characterClass"].GetValue() as string;
        if (playerClass?.ToLower() != "blacksmith") return;

        animdata.AnimationSpeed = 1.96f;
    }
}