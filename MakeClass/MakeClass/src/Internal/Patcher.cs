using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Vintagestory.GameContent;

namespace MakeClass.Internal;

[HarmonyPatch]
public static class Patcher
{
    public static Config.Config Config { private get; set; }

    public static Registry Registry { private get; set; }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(CharacterSystem), "loadCharacterClasses")]
    public static void ShowCharacterClasses(CharacterSystem __instance)
    {
        if (Config.DisableVanillaClasses)
        {
            __instance.traits = Registry.Traits.ToList();
            foreach (var trait in Registry.Traits)
            {
                __instance.TraitsByCode[trait.Code] = trait;
            }

            __instance.characterClasses = Registry.CharacterClasses.ToList();
            __instance.characterClassesByCode = new Dictionary<string, CharacterClass>();
            foreach (var character in Registry.CharacterClasses)
            {
                __instance.characterClassesByCode[character.Code] = character;
            }
        }
        else
        {
            foreach (var trait in Registry.Traits.Where(trait => !__instance.traits.Contains(trait)))
            {
                __instance.traits.Add(trait);
                __instance.TraitsByCode[trait.Code] = trait;
            }

            foreach (var characterClass in Registry.CharacterClasses.Where(characterClass =>
                         !__instance.characterClasses.Contains(characterClass)))
            {
                __instance.characterClasses.Add(characterClass);
                __instance.characterClassesByCode[characterClass.Code] = characterClass;
            }
        }
    }
}