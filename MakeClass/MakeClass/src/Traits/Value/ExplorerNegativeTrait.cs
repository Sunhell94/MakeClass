using MakeClass.Attribute;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Value;

public class ExplorerNegativeTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("explorerNegative")
            .Type(EnumTraitType.Negative)
            .Name("ru", "Слабые стороны Разведчика")
            .AddAttribute(new AnimalHarvestingSpeed(-0.5))
            .AddAttribute(new AnimalLootDropRate(-0.5))
            .AddAttribute(new ProduceDropRate(-0.5))
            .AddAttribute(new ForageDropRate(-0.3))
            .AddAttribute(new RangedWeaponsAccuracy(-0.25))
            .AddAttribute(new RangedWeaponsSpeed(-0.25))
            .AddAttribute(new RangedWeaponsDamage(-0.25))
            .AddAttribute(new BowDrawingStrength(-0.25))
            .AddAttribute(new OreDropRate(-0.2))
            .AddAttribute(new MiningSpeed(-0.15))
            .AddAttribute(new TemporalGearRepairCost(-1));
    }
}
