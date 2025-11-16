using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class RangerNegativeTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("rangerNegative")
            .Type(EnumTraitType.Negative)
            .Name("ru", "Слабые стороны Рейнджера")
            .AddAttribute(new MeleeWeaponsDamage(-0.25))
            .AddAttribute(new HungerRate(-0.15))
            .AddAttribute(new MiningSpeed(-0.15))
            .AddAttribute(new OreDropRate(-0.2));
    }
}
