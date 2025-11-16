using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class ExplorerTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("explorer")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Горняк")
            .MakeRecipeExclusive(new AssetLocation("bomb", "brickbomb"))
            .MakeRecipeExclusive(new AssetLocation("bomb", "brickbomb2"))
            .MakeRecipeExclusive(new AssetLocation("bomb", "brickbomb3"))
            .MakeRecipeExclusive(new AssetLocation("bomb", "orebarrel"))
            .MakeRecipeExclusive(new AssetLocation("bomb", "stonebarrel"))
            .MakeRecipeExclusive(new AssetLocation("bomb", "potbomb"))
            .MakeRecipeExclusive(new AssetLocation("game", "bomb-ore"))
            .MakeRecipeExclusive(new AssetLocation("game", "bomb-scrap"))
            .MakeRecipeExclusive(new AssetLocation("game", "bomb-ore"))
            .MakeRecipeExclusive(new AssetLocation("game", "bomb-stone"));
        
    }
} 
