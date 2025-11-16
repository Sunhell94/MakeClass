using System.Collections.Generic;
using MakeClass.Traits.Value;
using MakeClass.Traits.Craft;
using Vintagestory.API.Common;

namespace MakeClass.Classes;

public class RangerClass : CharacterClass
{
    private static readonly List<TraitBase> Traits = new()
    {
        new RangerPositiveTrait(),
        new RangerNegativeTrait()
    };

    private static readonly List<AssetLocation> Gear = new()
    {
        new("game", "clothes-upperbody-woolen-shirt"),
        new("game", "clothes-lowerbody-warm-woolen-pants"),
        new("game", "clothes-upperbodyover-cobalt-mantle"),
        new("game", "clothes-foot-soldier-boots"),
        new("game", "clothes-waist-peasant-strap"),
        new("game", "clothes-arm-leather-bracers"),
        new("game", "clothes-emblem-silver-pin")

    };

    public RangerClass() : base(Traits, Gear)
    {
    }

    protected override void Build()
    {
        Builder.Code("guard")
            .Name("ru", "Рейнджер")
            .Description("ru",
                """
                Хищник и следопыт, живущий между миром людей и дикой природой. Его добыча мясо и шкуры, его дом  дорога. Рейнджеры обеспечивают безопасность путешествий и охотятся за зверем, но без оружейников и мастеров быстро теряют силу.
                """
            );
    }
} 