using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class BeekeeperTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("beekeeper")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Пчеловод")
            .MakeRecipeExclusive(new AssetLocation("game", "fourclaypots"));
    }
}