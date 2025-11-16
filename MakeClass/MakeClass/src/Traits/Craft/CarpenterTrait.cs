using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class CarpenterTrait : TraitBase
{
    protected override void Build()
    {
        var barrelRecipe = new RecipeBuilder()
            .SetPattern("SPS, P ,SPS", 3, 3)
            .AddIngredient(
                'S',
                new CraftingRecipeIngredient
                {
                    Type = EnumItemClass.Item,
                    Code = new AssetLocation("game", "stick"),
                    Quantity = 2
                }
            )
            .AddIngredient(
                'P',
                new CraftingRecipeIngredient
                {
                    Type = EnumItemClass.Item,
                    Code = new AssetLocation("game", "plank-*"),
                    Quantity = 2
                }
            )
            .SetOutput(
                new CraftingRecipeIngredient
                {
                    Type = EnumItemClass.Block,
                    Code = new AssetLocation("game", "barrel")
                }
            )
            .Build(MakeClassModSystem.Api);

        var chestRecipe = new RecipeBuilder()
            .SetPattern("WWW,WNW,WWW", 3, 3)
            .AddIngredient(
                'W',
                new CraftingRecipeIngredient
                {
                    Type = EnumItemClass.Item,
                    Code = new AssetLocation("game", "plank-*")
                }
            )
            .AddIngredient(
                'N',
                new CraftingRecipeIngredient
                {
                    Type = EnumItemClass.Item,
                    Code = new AssetLocation("game", "metalnailsandstrips-*")
                }
            )
            .SetOutput(
                new CraftingRecipeIngredient
                {
                    Type = EnumItemClass.Block,
                    Code = new AssetLocation("game", "chest-east"),
                    Attributes = JsonObject.FromJson("{\"type\":\"normal-generic\"}")
                }
            )
            .Build(MakeClassModSystem.Api);        

        var paperLanternRecipe = new RecipeBuilder()
            .SetPattern("PYP,YTY,PYP", 3, 3)
            .AddIngredient('P', new CraftingRecipeIngredient
            {
                Type = EnumItemClass.Item,
                Quantity = 2,
                Code = new AssetLocation("game", "plank-*")
            })
            .AddIngredient('Y', new CraftingRecipeIngredient
            {
                Type = EnumItemClass.Item,
                Code = new AssetLocation("game", "paper-parchment")
            })
            .AddIngredient('T', new CraftingRecipeIngredient
            {
                Type = EnumItemClass.Item,
                Quantity = 1,
                Code = new AssetLocation("game", "candle")
            })
            .SetOutput(new CraftingRecipeIngredient
            {
                Type = EnumItemClass.Block,
                Code = new AssetLocation("game", "paperlantern-on"),
                Quantity = 1
            })
            .Build();

        var lanternOffRecipe = new RecipeBuilder()
            .ShouldPlaceInOrder()
            .SetPattern("P", 1, 1)
            .AddIngredient('P', new CraftingRecipeIngredient
            {
                Type = EnumItemClass.Block,
                Code = new AssetLocation("game", "paperlantern-on")
            })
            .SetOutput(new CraftingRecipeIngredient
            {
                Type = EnumItemClass.Block,
                Code = new AssetLocation("game", "paperlantern-off"),
                Quantity = 1
            })
            .Build();

        Builder
            .Code("carpenter")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Плотник")
            .MakeRecipeExclusive(new AssetLocation("game", "firewood"))
            .MakeRecipeExclusive(new AssetLocation("game", "wagonwheel"))
            .MakeRecipeExclusive(new AssetLocation("game", "wallpaper"))
            .MakeRecipeExclusive(new AssetLocation("game", "door"))
            .MakeRecipeExclusive(new AssetLocation("game", "rug"))
            .MakeRecipeExclusive(new AssetLocation("game", "rug"))
            .AddRecipe(barrelRecipe, new()
            {
                { "ru", "бочка" },
                { "en", "barrel" },
            })
            .AddRecipe(chestRecipe, new()
            {
                { "ru", "сундук" },
                { "en", "chest" },
            })
            .AddRecipe(paperLanternRecipe, new()
            {
                { "ru", "бумажный фонарь" },
                { "en", "paper lantern" },
            });
    }
}