using System.Collections.Generic;
using MakeClass.Traits.Value;
using MakeClass.Traits.Craft;
using Vintagestory.API.Common;

namespace MakeClass.Classes;

public class ForesterClass : CharacterClass
{
    private static readonly List<TraitBase> Traits = new()
    {
        new ForesterPositiveTrait(),
        new ForesterNegativeTrait(),
        new CarpenterTrait(),
        new PotterTrait()
    };

    private static readonly List<AssetLocation> Gear = new()
    {
        new("game", "clothes-upperbody-tailor-blouse"),
        new("game", "clothes-shoulder-jord-robe"),
        new("game", "clothes-lowerbody-workmans-gown"),
        new("game", "clothes-foot-worn-leather-boots"),
        new("game", "clothes-waist-heavy-tool-belt"),
        new("game", "clothes-nadiya-neck-purpleheart-amulet"),
        new("game", "clothes-nadiya-head-barber"),
    };

    public ForesterClass() : base(Traits, Gear)
    {
    }

    protected override void Build()
    {
        Builder.Code("forester")
            .Name("ru", "Лесничий")
            .Description("ru",
                """
                Осваивает дикую местность, где цивилизация едва касается земли. Из древесины, глины и травы делает нужное для всех.. Он знает лес лучше, чем улицы, но не умеет работать с металлом и камнем, потому всегда зависит от городских ремесленников.
                """
            );
    }
}