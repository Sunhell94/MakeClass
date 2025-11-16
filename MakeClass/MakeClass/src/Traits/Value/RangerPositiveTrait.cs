using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class RangerPositiveTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("rangerPositive")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Сильные стороны Рейнджера")
            .AddAttribute(new RangedWeaponsAccuracy(0.5))
            .AddAttribute(new RangedWeaponsSpeed(0.5))
            .AddAttribute(new RangedWeaponsDamage(0.5))
            .AddAttribute(new BowDrawingStrength(0.5))
            .AddAttribute(new AnimalHarvestingSpeed(0.5))
            .AddAttribute(new AnimalLootDropRate(0.5));
    }
}
