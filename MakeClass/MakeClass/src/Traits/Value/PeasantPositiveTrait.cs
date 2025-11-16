using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class PeasantPositiveTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("peasantpositive")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Сильные стороны Крестьянина")
            .AddAttribute(new ProduceDropRate(1))
            .AddAttribute(new ForageDropRate(0.6))
            .AddAttribute(new FruitTreeDropRate(0.2));
    }
}
