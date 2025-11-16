using System;
using System.Linq;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.API.Datastructures;
using MakeClass.Attribute;

namespace MakeClass.Internal
{
    public static class RecipeAccess
    {
        // Add a static reference to the server API so the prefix can log safely
        private static ICoreServerAPI Api;

        public static void Install(ICoreServerAPI api, Harmony h)
        {
            Api = api; // store for later logging

            var asm = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(a => a.GetName().Name == "VSSurvivalMod" ||
                                     a.GetName().Name == "Vintagestory.GameContent");
            if (asm == null) { api.Logger.Error("[MakeClass] VSSurvivalMod not found"); return; }

            var invType =
                asm.GetType("Vintagestory.GameContent.InventoryClayForming") ??
                asm.GetType("Vintagestory.GameContent.ClayFormingInventory");
            if (invType == null) { api.Logger.Error("[MakeClass] ClayForming inventory type not found"); return; }

            var layeredGen = asm.GetType("Vintagestory.GameContent.LayeredVoxelRecipe`1");
            var layered = layeredGen?.MakeGenericType(invType);
            if (layered == null) { api.Logger.Error("[MakeClass] LayeredVoxelRecipe<T> not found"); return; }

            var matches = AccessTools.Method(layered, "Matches");
            if (matches == null) { api.Logger.Error("[MakeClass] Matches() not found"); return; }

            h.Patch(matches, prefix: new HarmonyMethod(typeof(RecipeAccess), nameof(MatchesPrefix)));
            api.Logger.Notification("[MakeClass] Clay-forming recipe filter installed");
        }

        // Единственный префикс
        public static bool MatchesPrefix(object __instance, object inv, ref bool __result, IPlayer byPlayer)
        {
            try
            {
                var attrs = Traverse.Create(__instance).Field("Attributes").GetValue<JsonObject>();
                string needTrait = null;
                if (attrs != null && attrs.KeyExists("needTrait"))
                {
                    needTrait = attrs["needTrait"].AsString();
                }

                if (!string.IsNullOrEmpty(needTrait))
                {
                    // safe cast; TraitBuilder.Code expects IServerPlayer (original usage)
                    var serverPlayer = byPlayer as IServerPlayer;
                    if (!TraitBuilder.Code(serverPlayer, needTrait))
                    {
                        __result = false;   // блокируем рецепт
                        return false;       // не вызывать оригинал
                    }
                }

                return true;            // пропускаем к оригиналу
            }
            catch (Exception ex)
            {
                // don't break vanilla behavior on unexpected errors; just log
                Api?.Logger?.Error($"[MakeClass] MatchesPrefix error: {ex}");
                return true;
            }
        }
    }
}
