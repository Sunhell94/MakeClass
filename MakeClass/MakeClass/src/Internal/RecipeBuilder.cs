using System;
using System.Collections.Generic;
using System.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;

namespace MakeClass.Internal;

public class RecipeBuilder
{
    private string _pattern;
    private readonly Dictionary<char, CraftingRecipeIngredient> _ingredients = new();
    private CraftingRecipeIngredient _output;
    private int _width;
    private int _height;
    private bool _shapeless = false;

    public RecipeBuilder SetPattern(string pattern, int width, int height)
    {
        _pattern = pattern;
        _width = width;
        _height = height;
        return this;
    }

    public RecipeBuilder AddIngredient(char key, CraftingRecipeIngredient ingredient)
    {
        _ingredients[key] = ingredient;
        return this;
    }

    public RecipeBuilder SetOutput(CraftingRecipeIngredient output)
    {
        _output = output;
        return this;
    }

    /// <summary>
    /// Whether the order of input items should be respected
    /// </summary>
    public RecipeBuilder ShouldPlaceInOrder()
    {
        _shapeless = true;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="attr">
    /// Optional attribute data that you can attach any data to.
    /// Useful for code mods, but also required when using liquid ingredients.
    /// See dough. json grid recipe file for example.
    /// </param>
    /// <param name="averageDurability">
    /// If true, the output item will have its durability averaged over the input items
    /// </param>
    /// <param name="recipeGroup">
    /// Info used by the handbook.
    /// By default, all recipes for an object will appear in a single preview.
    /// This allows you to split grid recipe previews into multiple.
    /// </param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public GridRecipe Build(
        JsonObject attr = null,
        bool averageDurability = false,
        int recipeGroup = 0
    )
    {
        if (string.IsNullOrEmpty(_pattern) || _output == null || _ingredients.Count == 0)
        {
            throw new InvalidOperationException("Рецепт не полностью определен.");
        }

        var recipe = new GridRecipe
        {
            Name = $"{_output}:{_pattern}",
            IngredientPattern = _pattern,
            Width = _width,
            Height = _height,
            Output = _output,
            Ingredients = _ingredients.ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value),
            Attributes = attr,
            AverageDurability = averageDurability,
            RecipeGroup = recipeGroup,
            Shapeless = _shapeless
        };

        return recipe;
    }

    public GridRecipe Build(
        ICoreAPI api,
        JsonObject attr = null,
        bool averageDurability = false,
        int recipeGroup = 0
    )
    {
        if (string.IsNullOrEmpty(_pattern) || _output == null || _ingredients.Count == 0)
        {
            throw new InvalidOperationException("Рецепт не полностью определен.");
        }

        var recipe = new GridRecipe
        {
            Name = $"{_output}:{_pattern}",
            IngredientPattern = _pattern,
            Width = _width,
            Height = _height,
            Output = _output,
            Ingredients = _ingredients.ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value),
            Attributes = attr,
            AverageDurability = averageDurability,
            RecipeGroup = recipeGroup,
            Shapeless = _shapeless
        };

        return recipe;
    }
}