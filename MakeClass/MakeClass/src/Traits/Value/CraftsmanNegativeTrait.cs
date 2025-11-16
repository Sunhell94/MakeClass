using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class CraftsmanNegativeTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("craftsmanNegative")
            .Type(EnumTraitType.Negative)
            .Name("ru", "Слабые стороны Ремесленника")
            .AddAttribute(new RangedWeaponsAccuracy(-0.25))
            .AddAttribute(new RangedWeaponsSpeed(-0.25))
            .AddAttribute(new RangedWeaponsDamage(-0.25))
            .AddAttribute(new BowDrawingStrength(-0.25))
            .AddAttribute(new ProduceDropRate(-0.5))
            .AddAttribute(new ForageDropRate(-0.2))
            .AddAttribute(new AnimalSeekingRange(0.25))
            .AddAttribute(new WalkSpeed(-0.1));
    }
}
