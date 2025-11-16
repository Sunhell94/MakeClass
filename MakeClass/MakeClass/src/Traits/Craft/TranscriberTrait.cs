using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class TranscriberTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("transcriber")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Транскриптор")
            .MakeRecipeExclusive(new AssetLocation("game", "rug"))
            .MakeRecipeExclusive(new AssetLocation("game", "parchment"))
            .MakeRecipeExclusive(new AssetLocation("game", "paper"));
    }
} 
