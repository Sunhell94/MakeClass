using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class PotterTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("potter")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Гончар")
            .MakeRecipeExclusive(new AssetLocation("bulkmolds", "bulkarrowhead-raw"));
    }
}