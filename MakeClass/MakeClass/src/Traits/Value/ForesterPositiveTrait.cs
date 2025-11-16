using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class ForesterPositiveTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("foresterPositive")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Сильные стороны Лесоруба")
            .AddAttribute(new AnimalSeekingRange(-0.5))
            .AddAttribute(new WildCropDropRate(0.3))
            .AddAttribute(new CharcoalPileDropRate(0.5))
            .AddAttribute(new WoodDropRate(0.5))
            .AddAttribute(new StickDropRate(0.5))
            .AddAttribute(new TreeSeedDropRate(0.5));
    }
}
