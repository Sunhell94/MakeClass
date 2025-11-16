using System;
using System.Collections.Generic;
using Table = System.Collections.Generic.Dictionary<string, string>;

namespace MakeClass.Internal;

public class Translation : IEquatable<Translation>
{
    public readonly string Key;
    public string Body;

    public Translation(string key, string body)
    {
        Key = key;
        Body = body;
    }

    public bool Equals(Translation other) => other is not null && other.Key == Key;

    public override bool Equals(object obj) => Equals(obj as Translation);

    public override int GetHashCode() => Key.GetHashCode();

    public static bool operator ==(Translation v1, Translation v2)
    {
        if (v1 is null)
        {
            return v2 is null;
        }

        return v1.Equals(v2);
    }

    public static bool operator !=(Translation v1, Translation v2)
    {
        if (v1 is null)
        {
            return v2 is not null;
        }

        return !v1.Equals(v2);
    }
};

public static class TranslationTable
{
    private static readonly Dictionary<string, Table> Translations = new()
    {
        ["en"] = new Table
        {
            ["rangedWeaponsDamage"] = "Ranged Weapons Damage",
            ["rangedWeaponsAcc"] = "Ranged Weapons Accuracy",
            ["rangedWeaponsSpeed"] = "Ranged Weapons Speed",
            ["bowDrawingStrength"] = "Bow Drawing Strength",
            ["meleeWeaponsDamage"] = "Melee Weapons Damage",
            ["armorDurabilityLoss"] = "Armor Durability",
            ["armorWalkSpeedAffectedness"] = "Armor Walk Speed Penalty Reduction",
            ["animalLootDropRate"] = "Animal Loot Drop Rate",
            ["animalHarvestingSpeed"] = "Animal Harvesting Speed",
            ["forageDropRate"] = "Forage Drop Rate",
            ["wildCropDropRate"] = "Wild Crop Drop Rate",
            ["temporalGearDropRate"] = "Temporal Gear Drop Rate",
            ["rustyGearDropRate"] = "Rusty Gear Drop Rate",
            ["vesselContentsDropRate"] = "Vessel Contents Drop Rate",
            ["wholeVesselLootChance"] = "Whole Vessel Loot Chance",
            ["walkspeed"] = "Walk Speed",
            ["animalSeekingRange"] = "Animal Seeking Range",
            ["miningSpeedMul"] = "Mining Speed Multiplier",
            ["maxhealthExtraPoints"] = "Max Health Extra Points",
            ["oreDropRate"] = "Ore Drop Rate",
            ["healingeffectivness"] = "Healing Effectiveness",
            ["hungerrate"] = "Hunger Rate",
            ["mechanicalsDamageMul"] = "Mechanical Damage Multiplier",
            ["temporalGearTLRepairCost"] = "Temporal Gear Repair Cost Reduction",
            ["charcoalPileDropRate"] = "Charcoal Pile Drop Rate",
            ["woodDropRate"] = "Wood Drop Rate",
            ["fruittreeDropRate"] = "Fruit Tree Grafting Chance",
            ["treeseedDropRate"] = "Tree Seed Drop Rate",
            ["stickDropRate"] = "Stick Drop Rate",
            ["produceDropRate"] = "Produce Drop Rate",
        },
        ["ru"] = new Table
        {
            ["rangedWeaponsDamage"] = "урона в дальнем бою", //оф. перевод 
            ["rangedWeaponsAcc"] = "точности стрельбы", //оф. перевод 
            ["rangedWeaponsSpeed"] = "время прицеливания", //оф. перевод 
            ["bowDrawingStrength"] = "дальности стрельбы", //оф. перевод 
            ["meleeWeaponsDamage"] = "урона в ближнем бою", //оф. перевод 
            ["armorDurabilityLoss"] = "прочности брони", //оф. перевод
            ["armorWalkSpeedAffectedness"] =
                "снижения скорости ходьбы при ношении доспехов", //оф. перевод
            ["animalLootDropRate"] = "добычи с животных", //оф. перевод
            ["animalHarvestingSpeed"] = "скорости добычи животных", //оф. перевод
            ["forageDropRate"] = "добычи от собирательства", //оф. перевод
            ["vegetablesDropRate"] =
                "к сбору овощей", // из логики что например значение 1.2 будет отображаться как "+20% к сбору овощей"
            ["wildCropDropRate"] = "шанса добычи диких посевов", //оф. перевод
            ["temporalGearDropRate"] = "шанса добычи темпоральных шестерёнок", //по аналогии с ржавыми
            ["rustyGearDropRate"] = "шанса выпадения ржавых шестерёнок", //оф. перевод
            ["vesselContentsDropRate"] = "добычи из сосудов", //оф. перевод
            ["wholeVesselLootChance"] = "шанс собрать потрескавшиеся сосуды нетронутыми", //оф. перевод
            ["walkspeed"] = "скорости ходьбы", //оф. перевод
            ["animalSeekingRange"] = "дальности обнаружения животными", //оф. перевод
            ["miningSpeedMul"] = "скорости копания киркой", //оф. перевод, но идут споры 
            ["maxhealthExtraPoints"] = "очков здоровья", // из логики "+5 очков здоровья"
            ["oreDropRate"] = "шанса выпадения руды", // оф. перевод
            ["healingeffectivness"] = "эффективности лечения",
            ["hungerrate"] = "скорости голода", //оф. перевод
            ["mechanicalsDamageMul"] = "урона механизмам", //оф. перевод
            ["temporalGearTLRepairCost"] = "темпоральная шестерёнка для ремонта транслокатора",
            ["charcoalPileDropRate"] = "добычи древесного угля",
            ["woodDropRate"] = "добычи дерева",
            ["fruittreeDropRate"] = "добычи с плодовых деревьев",
            ["treeseedDropRate"] = "к добыче семян с деревьев",
            ["stickDropRate"] = "к добыче палок",
            ["produceDropRate"] = "дополнительной продукции при уборке посевных культур"
        }
    };

    private static Table GetTable(string locale)
    {
        if (locale is null) throw new ArgumentNullException(nameof(locale));

        if (Translations.TryGetValue(locale, out var table))
            return table;

        if (Translations.TryGetValue("en", out var enTable))
            return enTable;

        throw new ArgumentException($"Locale '{locale}' does not exist and no fallback 'en' available.");
    }

    /// <summary>
    /// Gets a localized translation for the given attribute. If no translation is found,
    /// returns the attribute's DisplayValue().
    /// </summary>
    public static string GetTranslation(string locale, Attribute.Attribute attribute)
    {
        if (attribute is null) throw new ArgumentNullException(nameof(attribute));

        var table = GetTable(locale);

        if (table.TryGetValue(attribute.Key, out var translation) && !string.IsNullOrEmpty(translation))
        {
            var sign = Math.Sign(attribute.Value) switch
            {
                0 | 1 => "+",
                _ => ""
            };

            return $"{sign}{attribute.DisplayValue()} {translation}";
        }

        return attribute.DisplayValue();
    }
}