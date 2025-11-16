using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class MercenaryNegativeTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("mercenaryNegative")
            .Type(EnumTraitType.Negative)
            .Name("ru", "Слабые стороны Наемника")
            .AddAttribute(new WildCropDropRate(-0.3))
            .AddAttribute(new HungerRate(0.15))
            .AddAttribute(new MiningSpeed(-0.15))
            .AddAttribute(new OreDropRate(-0.15))
            .AddAttribute(new AnimalSeekingRange(0.25))
            .AddAttribute(new OreDropRate(-0.15));
    }
}
