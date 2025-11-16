using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class CraftsmanTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("craftsman")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Ремесленник")
            .MakeRecipeExclusive(new AssetLocation("game", "bow-composite"))
            .MakeRecipeExclusive(new AssetLocation("game", "bow-recurve"))
            .MakeRecipeExclusive(new AssetLocation("game", "bow-long"))
            .MakeRecipeExclusive(new AssetLocation("game", "bow-curved"))
            .MakeRecipeExclusive(new AssetLocation("game", "crossbow"))
            .MakeRecipeExclusive(new AssetLocation("maltiezcrossbows", "bow-composite-heavy"));
    }
} 
