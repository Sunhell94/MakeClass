using System.Collections.Generic;
using MakeClass.Traits.Value;
using MakeClass.Traits.Craft;
using Vintagestory.API.Common;

namespace MakeClass.Classes;

public class MinerClass : CharacterClass
{
    private static readonly List<TraitBase> Traits = new()
    {
        new MinerPositiveTrait(),
        new MinerNegativeTrait(),
        new MasonTrait(),
        new ExplorerTrait()
    };

    private static readonly List<AssetLocation> Gear = new()
    {
        new("game", "clothes-upperbody-homespun-shirt"),
        new("game", "clothes-upperbodyover-marketeer"),
        new("game", "clothes-lowerbody-warm-woolen-pants"),
        new("game", "clothes-nadiya-foot-miner-clean"),
        new("game", "clothes-nadiya-waist-miner-accessori"),
        new("game", "clothes-head-squire-hood")
    };

    public MinerClass() : base(Traits, Gear)
    {
    }

    protected override void Build()
    {
        Builder.Code("miner")
            .Name("ru", "Шахтер")
            .Description("ru",
                """
                Опускается в глубины, где не видно солнца, и добывает дыхание металла. Без него не существует кузнецов, строителей и воинов. Шахтёр должен быть терпелив. Он хрупок и не умеет создавать, лишь передаёт добытое в руки других.
                """
            );
    }
} 