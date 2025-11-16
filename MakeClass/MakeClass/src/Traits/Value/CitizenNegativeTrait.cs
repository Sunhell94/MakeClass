using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class CitizenNegativeTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("citizenNegative")
            .Type(EnumTraitType.Negative)
            .Name("ru", "Слабые стороны Горожанина")
            .AddAttribute(new AnimalHarvestingSpeed(-0.5))
            .AddAttribute(new AnimalLootDropRate(-0.5))
            .AddAttribute(new HealingEffectiveness(0.1))
            .AddAttribute(new MaxHealth(2.5))
            .AddAttribute(new ArmorWalkSpeedMul(0.25))
            .AddAttribute(new ArmorDurabilityLoss(0.35))                        
            .AddAttribute(new MiningSpeed(-0.15))
            .AddAttribute(new HungerRate(0.15))
            .AddAttribute(new VegetableDropRate(-0.5));
    }
}
