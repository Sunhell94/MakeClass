using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class ForesterNegativeTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("foresterNegative")
            .Type(EnumTraitType.Negative)
            .Name("ru", "Слабые стороны Лесоруба")
            .AddAttribute(new AnimalHarvestingSpeed(-0.5))
            .AddAttribute(new AnimalLootDropRate(-0.5))
            .AddAttribute(new ArmorWalkSpeedMul(1.25))
            .AddAttribute(new ArmorDurabilityLoss(0.35))
            .AddAttribute(new ProduceDropRate(-0.5))
            .AddAttribute(new ForageDropRate(-0.3))
            .AddAttribute(new OreDropRate(-0.20))
            .AddAttribute(new MeleeWeaponsDamage(-0.25));
    }
}
