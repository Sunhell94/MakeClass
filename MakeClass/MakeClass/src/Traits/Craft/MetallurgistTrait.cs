using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class MetallurgistTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("metallurgist")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Кузнец")
            .MakeRecipeExclusive(new AssetLocation("game", "ironbloom"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "lock-wheellock-tinbronze"))
            .MakeRecipeExclusive(
                new AssetLocation("maltiezfirearms", "lock-wheellock-bismuthbronze")
            )
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "lock-wheellock-blackbronze"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "lock-matchlock-iron"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "lock-flintlock-steel"))
            .MakeRecipeExclusive(
                new AssetLocation("maltiezfirearms", "lock-matchlock-meteoriciron")
            );
    }
}