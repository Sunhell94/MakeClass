using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class MasonTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("mason")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Каменщик")
            .MakeRecipeExclusive(new AssetLocation("game", "mortar"))
            .MakeRecipeExclusive(new AssetLocation("game", "firebrick"))
            .MakeRecipeExclusive(new AssetLocation("game", "brick"))
            .MakeRecipeExclusive(new AssetLocation("game", "stonebrick"))
            .MakeRecipeExclusive(new AssetLocation("game", "brick-brown"))
            .MakeRecipeExclusive(new AssetLocation("game", "plaster"));
    }
} 
