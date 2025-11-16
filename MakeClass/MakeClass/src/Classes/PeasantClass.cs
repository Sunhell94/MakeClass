using System.Collections.Generic;
using MakeClass.Traits.Value;
using MakeClass.Traits.Craft;
using Vintagestory.API.Common;

namespace MakeClass.Classes;

public class PeasantClass : CharacterClass
{
    private static readonly List<TraitBase> Traits = new()
    {
        new PeasantPositiveTrait(),
        new PeasantNegativeTrait(),
        new BeekeeperTrait()
    };

    private static readonly List<AssetLocation> Gear = new()
    {
        new("game", "clothes-shoulder-jord-robe"),
        new("game", "clothes-upperbody-pastoral-shirt"),
        new("game", "clothes-lowerbody-workmans-gown"),
        new("game", "clothes-foot-worn-leather-boots"),
        new("game", "clothes-waist-linen-rope"),
        new("game", "clothes-nadiya-face-grain"),
        new("game", "clothes-head-straw-hat")
        
    };

    public PeasantClass() : base(Traits, Gear)
    {
    }

    protected override void Build()
    {
        Builder.Code("peasant")
            .Name("ru", "Крестьянин")
            .Description("ru",
                """
                Живёт землёй и трудом своих рук. На фермах и пастбищах растит урожай, скот и птицу, наполняя кладовые поселений. Крестьяне кормят города, но сами редко уходят далеко, за стенами им небезопасно. Их сила в укоренённости, а не в скитаниях.
                """
            );
    }
} 