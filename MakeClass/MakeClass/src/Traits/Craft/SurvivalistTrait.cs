using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class SurvivalistTrait : TraitBase
{
    protected override void Build()
    {
         var copperSwordRecipe = new RecipeBuilder()
            .SetPattern("NC", 1, 2)
            .AddIngredient(
                'N',
                new CraftingRecipeIngredient
                {
                    Type = EnumItemClass.Item,
                    Code = new AssetLocation("game", "stick"),
                    Quantity = 1
                }
            )
            .AddIngredient(
                'C',
                new CraftingRecipeIngredient
                {
                    Type = EnumItemClass.Item,
                    Code = new AssetLocation("game", "nugget-nativecopper"),
                    Quantity = 12
                }
            )
            .SetOutput(
                new CraftingRecipeIngredient
                {
                    Type = EnumItemClass.Item,
                    Code = new AssetLocation("game", "blade-falx-copper")
                }
            )
            .Build(MakeClassModSystem.Api);
        Builder
            .Code("survivalist")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Импровизатор")
            .AddRecipe(copperSwordRecipe, new()
            {
                { "ru", "медный фалькс" },
                { "en", "copper falx" },
            });
    }
} 
