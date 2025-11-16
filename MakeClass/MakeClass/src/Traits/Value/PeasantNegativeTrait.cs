using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class PeasantNegativeTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("peasantnegative")
            .Type(EnumTraitType.Negative)
            .Name("ru", "Слабые стороны Крестьянина")
            .AddAttribute(new AnimalHarvestingSpeed(-0.5))
            .AddAttribute(new AnimalLootDropRate(-0.5))
            .AddAttribute(new AnimalSeekingRange(0.25))
            .AddAttribute(new HungerRate(0.15))
            .AddAttribute(new WildCropDropRate(-0.30))
            .AddAttribute(new WalkSpeed(-0.10));
    }
}
