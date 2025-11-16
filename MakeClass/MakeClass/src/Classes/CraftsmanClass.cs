using System.Collections.Generic;
using MakeClass.Traits.Value;
using MakeClass.Traits.Craft;
using Vintagestory.API.Common;

namespace MakeClass.Classes;

public class CraftsmanClass : CharacterClass
{
    private static readonly List<TraitBase> Traits = new()
    {
        new CraftsmanNegativeTrait(),
        new WatchmakerTrait(),
        new TechnicianTrait(),
        new MetallurgistTrait(),
        new CraftsmanTrait()
    };

    private static readonly List<AssetLocation> Gear = new()
    {
        new("game", "clothes-nadiya-shoulder-blacksmith"),
        new("game", "clothes-upperbody-linen-tunic"),
        new("game", "clothes-lowerbody-commoner-trousers"),
        new("game", "clothes-nadiya-foot-blacksmith"),
        new("game", "clothes-hand-heavy-leather-gloves")
    };

    public CraftsmanClass() : base(Traits, Gear)
    {
    }

    protected override void Build()
    {
        Builder
            .Code("blacksmith")
            .Name("ru", "Мастер")
            .Description(
                "ru",
                """
                Кует, латает, создаёт. Его ремесло  источник силы общин, опора воинов и строителей. Без мастеров не бывает прогресса, но за пределами городских стен их руки бесполезны: без руды, топлива и заказов мастерство теряет смысл.
                """
            );
    }
}