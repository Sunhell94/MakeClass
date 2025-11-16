using System.Collections.Generic;
using MakeClass.Traits.Value;
using MakeClass.Traits.Craft;
using Vintagestory.API.Common;

namespace MakeClass.Classes;

public class MercenaryClass : CharacterClass
{
    private static readonly List<TraitBase> Traits = new()
    {
        new MercenaryPositiveTrait(),
        new MercenaryNegativeTrait()
    };

    private static readonly List<AssetLocation> Gear = new()
    {
        new("game", "clothes-upperbody-reindeer-herder-c"),
        new("game", "clothes-lowerbody-warm-woolen-pants"),
        new("game", "clothes-upperbodyover-malefactor-tunic"),
        new("game", "clothes-foot-forlorn-shoes"),
        new("game", "clothes-arm-leather-bracers"),
        new("game", "clothes-waist-heavy-belt")
    };

    public MercenaryClass() : base(Traits, Gear)
    {
    }

    protected override void Build()
    {
        Builder.Code("mercenary")
            .Name("ru", "Наемник")
            .Description("ru",
                """
                Живёт битвой и для битвы. Там, где другие ищут ресурсы, он ищет соперников. Очищает дороги и подземелья, держит удар за тех, кто не умеет. Но вне сражений ему неуютно: без врага мир становится скучным и пустым.
                """
            );
    }
} 