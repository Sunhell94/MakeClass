using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class WatchmakerTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("tinkerer")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Часовщик")
            .MakeRecipeExclusive(new AssetLocation("game", "locusttrap"));
    }
} 
