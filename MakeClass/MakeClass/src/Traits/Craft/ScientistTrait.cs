using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class ScientistTrait : TraitBase
{
    protected override void Build()
    {
         var recipeSulfur = new RecipeBuilder()
             .SetPattern("AB", 2, 1)
             .AddIngredient('A',
                 new CraftingRecipeIngredient
                     { Type = EnumItemClass.Item, Code = new AssetLocation("game", "rot"), Quantity = 4})
             .AddIngredient('B',
                 new CraftingRecipeIngredient
                     { Type = EnumItemClass.Item, Code = new AssetLocation("game", "lime") })
             .SetOutput(new CraftingRecipeIngredient
                 { Type = EnumItemClass.Item, Code = new AssetLocation("game", "ore-sulfur") })
             .Build();
        
         var recipeSaltpeter = new RecipeBuilder()
             .SetPattern("AB", 2, 1)
             .AddIngredient('A',
                 new CraftingRecipeIngredient
                     { Type = EnumItemClass.Item, Code = new AssetLocation("game", "rot"), Quantity = 4})
             .AddIngredient('B',
                 new CraftingRecipeIngredient
                     { Type = EnumItemClass.Item, Code = new AssetLocation("game", "drygrass") })
             .SetOutput(new CraftingRecipeIngredient
                 { Type = EnumItemClass.Item, Code = new AssetLocation("game", "saltpeter") })
             .Build();

        Builder
            .Code("scientist")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Ученый")
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "gunpowder-wet"))
            .MakeRecipeExclusive(new AssetLocation("game", "blastingpowder"))
            .MakeRecipeExclusive(new AssetLocation("game", "sulfur"))
            .MakeRecipeExclusive(new AssetLocation("game", "saltpeter"))
         .AddRecipe(recipeSaltpeter, new Dictionary<string, string>())
         .AddRecipe(recipeSulfur, new Dictionary<string, string>());
    }
}