using System.Collections.Generic;
using MakeClass.Traits.Value;
using MakeClass.Traits.Craft;
using Vintagestory.API.Common;

namespace MakeClass.Classes;

public class CitizenClass : CharacterClass
{
    private static readonly List<TraitBase> Traits = new()
    {
        new CitizenNegativeTrait(),
        new ClothierTrait(),
        new TailorTrait(),
        new ScientistTrait(),
        new TranscriberTrait(),
        new FieldMedicTrait()
    };

    private static readonly List<AssetLocation> Gear = new()
    {
        new("game", "clothes-upperbody-tailor-blouse"),
        new("game", "clothes-lowerbody-reindeer-herder-trousers"),
        new("game", "clothes-shoulder-artisans-scarf"),
        new("game", "clothes-foot-wool-lined-knee-high-boots"),
        new("game", "clothes-arm-tailor-needlepuff"),
        new("game", "clothes-face-glasses"),
        new("game", "clothes-nadiya-head-alchemist")
    };

    public CitizenClass() : base(Traits, Gear)
    {
    }

    protected override void Build()
    {
        Builder.Code("tailor")
            .Name("ru", "Горожанин")
            .Description("ru",
                """
                Сердце торговли и ремесла. Живёт среди рынков, мастерских и сделок, превращая труд других в движение серебра. Он держит на себе всю хозяйственную сеть, но стоит выйти за пределы города и жизнь превращается в испытание.
                """
            );
    }
} 