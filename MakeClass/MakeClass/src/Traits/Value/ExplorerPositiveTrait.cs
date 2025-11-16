using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class ExplorerPositiveTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("explorerPositive")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Сильные стороны Разведчика")
            .AddAttribute(new WalkSpeed(0.15))
            .AddAttribute(new VesselContentsDropRate(2.0))
            .AddAttribute(new RustyGearDropRate(2.0))
            .AddAttribute(new HungerRate(-0.15));
    }
}
