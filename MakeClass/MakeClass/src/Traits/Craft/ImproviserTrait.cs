using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class ImproviserTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("improviser")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Импровизатор")
            .MakeRecipeExclusive(new AssetLocation("game", "sling"));
    }
} 
