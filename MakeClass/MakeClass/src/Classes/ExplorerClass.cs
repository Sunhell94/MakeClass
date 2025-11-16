using System.Collections.Generic;
using MakeClass.Traits.Value;
using MakeClass.Traits.Craft;
using Vintagestory.API.Common;

namespace MakeClass.Classes;

public class ExplorerClass : CharacterClass
{
    private static readonly List<TraitBase> Traits = new()
    {
        new ExplorerPositiveTrait(),
        new ExplorerNegativeTrait(),
        new SurvivalistTrait()
    };

    private static readonly List<AssetLocation> Gear = new()
    {
        new("game", "clothes-shoulder-hooded-cape"),
        new("game", "clothes-upperbody-survivor"),
        new("game", "clothes-lowerbody-survivor"),
        new("game", "clothes-foot-survivor"),
        new("game", "clothes-waist-linen-rope"),
        new("game", "clothes-face-survivor"),
        new("game", "clothes-neck-malefactor-pendant")
        
    };

    public ExplorerClass() : base(Traits, Gear)
    {
    }

    protected override void Build()
    {
        Builder.Code("marauder")
            .Name("ru", "Исследователь")
            .Description("ru",
                """
                Странствует вдали от обжитых земель, ведомый любопытством и тягой к неизведанному. Бродит по подземельям и руинам, открывает забытые тропы и редкие источники. В одиночестве чувствует себя свободно, но в городских благах он нуждается больше, чем признаётся.
                """
            );
    }
} 