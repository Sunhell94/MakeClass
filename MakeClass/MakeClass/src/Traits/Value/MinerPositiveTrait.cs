using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class MinerPositiveTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("minerPositive")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Сильные стороны Шахтера")
            .AddAttribute(new MiningSpeed(0.5))
            .AddAttribute(new OreDropRate(0.4));
    }
}
