using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class MinerNegativeTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("minerNegative")
            .Type(EnumTraitType.Negative)
            .Name("ru", "Слабые стороны Шахтера")
            .AddAttribute(new RangedWeaponsAccuracy(-0.25))
            .AddAttribute(new RangedWeaponsSpeed(-0.25))
            .AddAttribute(new RangedWeaponsDamage(-0.25))
            .AddAttribute(new BowDrawingStrength(-0.25))
            .AddAttribute(new ForageDropRate(-0.3))
            .AddAttribute(new WildCropDropRate(-0.3))
            .AddAttribute(new MaxHealth(-2.5))
            .AddAttribute(new HealingEffectiveness(-0.1))
            .AddAttribute(new ArmorWalkSpeedMul(1.25))
            .AddAttribute(new ArmorDurabilityLoss(0.35));
    }
}
