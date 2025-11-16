using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class HerbalistTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("herbalist")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Травничество")
            .MakeRecipeExclusive(new AssetLocation("game", "poultice-linen-horsetaill"))
            .MakeRecipeExclusive(new AssetLocation("game", "poultice-reed-horsetaill"));
    }
} 
