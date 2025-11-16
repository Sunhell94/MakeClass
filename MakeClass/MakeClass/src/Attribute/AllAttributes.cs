using System.Globalization;
namespace MakeClass.Attribute;

public sealed class BowDrawingStrength : Attribute
{
    public BowDrawingStrength(double value) : base(value)
    {
    }

    public override string Key => "bowDrawingStrength";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class RangedWeaponsSpeed : Attribute
{
    public RangedWeaponsSpeed(double value) : base(value)
    {
    }

    public override string Key => "rangedWeaponsSpeed";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class RangedWeaponsDamage : Attribute
{
    public RangedWeaponsDamage(double value) : base(value)
    {
    }

    public override string Key => "rangedWeaponsDamage";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class RangedWeaponsAccuracy : Attribute
{
    public RangedWeaponsAccuracy(double value) : base(value)
    {
    }

    public override string Key => "rangedWeaponsAcc";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public class GliderLiftMax : Attribute
{
    public GliderLiftMax(double value) : base(value)
    {
    }

    public override string Key => "gliderLiftMax";
    public override string DisplayValue()
    {
        return ((int)Value).ToString();
    }
}
public class GliderSpeedMax : Attribute
{
    public GliderSpeedMax(double value) : base(value)
    {
    }

    public override string Key => "gliderSpeedMax";
    public override string DisplayValue()
    {
        return ((int)Value).ToString();
    }
}
public sealed class HealingEffectiveness : Attribute
{
    public HealingEffectiveness(double value) : base(value)
    {
    }

    public override string Key => "healingeffectivness";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class HungerRate : Attribute
{
    public HungerRate(double value) : base(value)
    {
    }

    public override string Key => "hungerrate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public class JumpHeightMul : Attribute
{
    public JumpHeightMul(double value) : base(value)
    {
    }

    public override string Key => "jumpHeightMul";

    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class MaxHealth : Attribute
{
    public MaxHealth(double value) : base(value)
    {
    }

    public override string Key { get; } = "maxhealthExtraPoints";

    public override string DisplayValue()
    {
        return Value.ToString(CultureInfo.InvariantCulture);
    }
}
public sealed class MiningSpeed : Attribute
{
    public MiningSpeed(double value) : base(value)
    {
    }

    public override string Key => "miningSpeedMul";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class WalkSpeed : Attribute
{
    public WalkSpeed(double value) : base(value)
    {
    }

    public override string Key => "walkspeed";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class FruitTreeDropRate : Attribute
{
    public FruitTreeDropRate(double value) : base(value)
    {
    }

    public override string Key => "fruittreeDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class StickDropRate : Attribute
{
    public StickDropRate(double value) : base(value)
    {
    }

    public override string Key => "stickDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class TreeSeedDropRate : Attribute
{
    public TreeSeedDropRate(double value) : base(value)
    {
    }

    public override string Key => "treeseedDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class WoodDropRate : Attribute
{
    public WoodDropRate(double value) : base(value)
    {
    }

    public override string Key => "woodDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class MeleeWeaponsDamage : Attribute
{
    public MeleeWeaponsDamage(double value) : base(value)
    {
    }

    public override string Key => "meleeWeaponsDamage";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class MechanicalsDamageMul : Attribute
{
    public MechanicalsDamageMul(double value) : base(value)
    {
    }

    public override string Key => "mechanicalsDamageMul";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class CharcoalPileDropRate : Attribute
{
    public CharcoalPileDropRate(double value) : base(value)
    {
    }

    public override string Key => "charcoalPileDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
/// Злаковые
public sealed class ForageDropRate : Attribute
{
    public ForageDropRate(double value) : base(value)
    {
    }

    public override string Key => "forageDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class OreDropRate : Attribute
{
    public OreDropRate(double value) : base(value)
    {
    }

    public override string Key => "oreDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class ProduceDropRate : Attribute
{
    public ProduceDropRate(double value) : base(value)
    {
    }

    public override string Key => "produceDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class RustyGearDropRate : Attribute
{
    public RustyGearDropRate(double value) : base(value)
    {
    }

    public override string Key => "rustyGearDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class TemporalGearRepairCost : Attribute
{
    public TemporalGearRepairCost(double value) : base(value)
    {
    }

    public override string Key => "temporalGearTLRepairCost";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class VegetableDropRate : Attribute
{
    public VegetableDropRate(double value) : base(value)
    {
    }

    public override string Key => "vegetablesDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class VesselContentsDropRate : Attribute
{
    public VesselContentsDropRate(double value) : base(value)
    {
    }

    public override string Key => "vesselContentsDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class WholeVesselLootChance : Attribute
{
    public WholeVesselLootChance(double value) : base(value)
    {
    }

    public override string Key => "wholeVesselLootChance";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class WildCropDropRate : Attribute
{
    public WildCropDropRate(double value) : base(value)
    {
    }

    public override string Key => "wildCropDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public class ArmorDurabilityLoss : Attribute
{
    public ArmorDurabilityLoss(double value) : base(value)
    {
    }

    public override string Key => "armorDurabilityLoss";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class ArmorWalkSpeedMul : Attribute
{
    public ArmorWalkSpeedMul(double value) : base(value)
    {
    }

    public override string Key => "armorWalkSpeedAffectedness";
    public override string DisplayValue() => $"{Value * 100:0}%";
}
public sealed class AnimalHarvestingSpeed : Attribute
{
    public AnimalHarvestingSpeed(double value) : base(value)
    {
    }

    public override string Key => "animalHarvestingSpeed";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class AnimalLootDropRate : Attribute
{
    public AnimalLootDropRate(double value) : base(value)
    {
    }

    public override string Key => "animalLootDropRate";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}
public sealed class AnimalSeekingRange : Attribute
{
    public AnimalSeekingRange(double value) : base(value)
    {
    }

    public override string Key => "animalSeekingRange";
    public override string DisplayValue() => (Value * 100).ToString("0") + "%";
}