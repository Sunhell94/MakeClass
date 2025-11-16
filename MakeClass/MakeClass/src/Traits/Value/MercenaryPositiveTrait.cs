using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class MercenaryPositiveTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("mercenaryPositive")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Сильные стороны Наемника")
            .AddAttribute(new HealingEffectiveness(0.2))
            .AddAttribute(new MeleeWeaponsDamage(0.5))
            .AddAttribute(new MechanicalsDamageMul(3))
            .AddAttribute(new MaxHealth(5))
            .AddAttribute(new ArmorDurabilityLoss(-0.1))
            .AddAttribute(new ArmorWalkSpeedMul(0.65));
    }
}
