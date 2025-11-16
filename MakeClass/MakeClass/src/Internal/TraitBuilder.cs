using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace MakeClass.Internal;

public class TraitBuilder
{
    private List<GridRecipe> _recipes = new();

    private Dictionary<string, HashSet<Translation>> _translations = new();

    private List<Attribute.Attribute> _attributes = new();

    private List<AssetLocation> _exclusiveCrafts = new();

    private readonly Trait _trait = new()
    {
        Attributes = new Dictionary<string, double>()
    };

    private string GetTraitDesc()
    {
        return $"traitdesc-{_trait.Code}";
    }

    public TraitBuilder Code(string code)
    {
        _trait.Code = code;
        return this;
    }

    public TraitBuilder Type(EnumTraitType type)
    {
        _trait.Type = type;
        return this;
    }

    public TraitBuilder AddAttribute(Attribute.Attribute attribute)
    {
        _attributes.Add(attribute);
        return this;
    }

    /// <summary>
    /// Add locale to trait, attributes translates automatically, need to be called after <seealso cref="Code"/>>
    /// </summary>
    /// <param name="locale"></param>
    /// <param name="translation"></param>
    /// <returns></returns>
    public TraitBuilder Name(string locale, string translation)
    {
        if (string.IsNullOrEmpty(_trait.Code))
        {
            throw new InvalidOperationException("Code must be set.");
        }

        var color = _trait.Type switch
        {
            EnumTraitType.Positive => "#a7c957",
            EnumTraitType.Mixed => "#ffe6a7",
            EnumTraitType.Negative => "#e0443f",
            _ => "#ffffff"
        };

        var traitName = new Translation($"traitname-{_trait.Code}", translation);
        AddTranslation(locale, traitName);

        translation = $"<font color=\"{color}\">{translation}</font>";
        var trait = new Translation($"trait-{_trait.Code}", translation);
        AddTranslation(locale, trait);
        return this;
    }

    /// <summary>
    /// Show only when trait have 0 attributes
    /// </summary>
    /// <param name="locale"></param>
    /// <param name="translation"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public TraitBuilder Description(string locale, string translation)
    {
        if (string.IsNullOrEmpty(_trait.Code))
        {
            throw new InvalidOperationException("Code must be set.");
        }

        var tr = new Translation($"", translation);
        AddTranslation(locale, tr);
        return this;
    }

    /// <summary>
    /// Add a special for the trait recipe 
    /// </summary>
    /// <param name="recipe">The recipe to add</param>
    /// <param name="outputNames">Dictionary of output item names for each locale (e.g., "ru" -> "набор для шитья", "en" -> "sewing kit")</param>
    /// <returns></returns>
    public TraitBuilder AddRecipe(GridRecipe recipe, Dictionary<string, string> outputNames)
    {
        if (string.IsNullOrEmpty(_trait.Code))
        {
            throw new InvalidOperationException("Code must be set.");
        }

        recipe.RequiresTrait = _trait.Code;

        foreach (var (locale, value) in _translations)
        {
            if (!outputNames.TryGetValue(locale, out var outputName)) continue;

            outputName = outputName[0].ToString().ToUpper() + outputName[1..];

            var link = $"<a href=\"handbooksearch://{outputName}\">{outputName}</a>";

            var descKey = $"traitdesc-{_trait.Code}";
            var tr = value.FirstOrDefault(t => t.Key == descKey);
            if (tr != null)
            {
                tr.Body += $", {link}";
            }
            else
            {
                tr = new Translation(descKey, $"{link}");
                value.Add(tr);
            }
        }

        _recipes.Add(recipe);
        return this;
    }

    public TraitBuilder MakeRecipeExclusive(AssetLocation asset)
    {
        _exclusiveCrafts.Add(asset);
        return this;
    }

    private void AddTranslation(string locale, Translation tr)
    {
        var exists = _translations.TryGetValue(locale, out var hashSet);
        if (!exists)
        {
            hashSet = new HashSet<Translation> { tr };
            _translations.TryAdd(locale, hashSet);
        }

        hashSet.Add(tr);
    }


    public Trait Registry(Registry registry)
    {
        if (string.IsNullOrEmpty(_trait.Code))
        {
            throw new InvalidOperationException("Code must be set.");
        }

        _trait.Attributes = _attributes.ToHashSet()
            .ToDictionary(attribute => attribute.Key, attribute => attribute.Value);

        foreach (var attribute in _attributes)
        {
            foreach (var trPair in _translations.ToList())
            {
                var key = $"charattribute-{attribute.Key}-{attribute.Value.ToString(CultureInfo.InvariantCulture)}";
                var translation = TranslationTable.GetTranslation(trPair.Key, attribute);

                var tr = new Translation(key, translation);
                var exists = _translations.TryGetValue(trPair.Key, out var hashSet);
                if (!exists)
                {
                    hashSet = new HashSet<Translation> { tr };
                    _translations.TryAdd(trPair.Key, hashSet);
                }

                hashSet.Add(tr);
            }
        }

        if (registry.Api is ICoreServerAPI sapi)
        {
            RecipePatcher(sapi);
            ResolveRecipes(sapi);
        }

        registry.RegisterTrait(_trait, _translations);

        return _trait;
    }

    private void RecipePatcher(ICoreServerAPI api)
    {
        foreach (var asset in _exclusiveCrafts)
        {
            var assetRecipes = api.World.GridRecipes.Where(recipe => recipe.Output.Code == asset).ToList();
            foreach (var recipe in assetRecipes)
            {
                try
                {
                    recipe.RequiresTrait = _trait.Code;
                    if (!recipe.ResolveIngredients(api.World)) continue;
                    api.RegisterCraftingRecipe(recipe);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }

    private void ResolveRecipes(ICoreServerAPI api)
    {
        var resolvedRecipes = new List<GridRecipe>();
        foreach (var resolved in _recipes.Select(recipe => ResolveOutput(api.World, recipe)))
        {
            resolvedRecipes.AddRange(resolved);
        }

        foreach (var recipe in resolvedRecipes)
        {
            try
            {
                if (!recipe.ResolveIngredients(api?.World)) continue;
                api?.RegisterCraftingRecipe(recipe);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    private bool IsHavePlaceholder(string code)
    {
        var parts = code.Split('-');
        var have = false;
        foreach (var part in parts)
        {
            if (have) return true;
            have = part.StartsWith('{');
            have &= part.EndsWith('}');
        }

        return have;
    }

    private List<GridRecipe> ResolveOutput(IWorldAccessor world, GridRecipe recipe)
    {
        if (!IsHavePlaceholder(recipe.Output.Code)) return new List<GridRecipe> { recipe };
        var mappings = recipe.GetNameToCodeMapping(world);
        if (mappings.Count == 0) return new List<GridRecipe> { recipe };

        var resolvedPlaceHolderRecipes = new List<GridRecipe>();
        foreach (var (key, variants) in mappings)
        {
            foreach (var variant in variants)
            {
                var recipeClone = recipe.Clone();
                if (recipe.Ingredients != null)
                {
                    foreach (var ingredKP in recipeClone.Ingredients)
                    {
                        var ingred = ingredKP.Value;
                        if (ingred.Name == key)
                        {
                            ingred.Code =
                                ingred.Code.CopyWithPath(ingred.Code.Path.Replace("*", variant));
                        }
                    }
                }

                recipeClone.Output.FillPlaceHolder(key, variant);
                resolvedPlaceHolderRecipes.Add(recipeClone);
            }
        }

        return resolvedPlaceHolderRecipes;
    }
}