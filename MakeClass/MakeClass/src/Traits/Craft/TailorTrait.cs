using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class TailorTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("tailor")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Портной")
            .MakeRecipeExclusive(new AssetLocation("game", "linensack"))
            .MakeRecipeExclusive(new AssetLocation("game", "miningbag"))
            .MakeRecipeExclusive(new AssetLocation("game", "clothes-upperbodyover-fur-coat"))
            .MakeRecipeExclusive(new AssetLocation("game", "sewingkit"));
    }
} 
