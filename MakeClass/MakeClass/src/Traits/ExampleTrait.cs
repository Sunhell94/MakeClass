using System.Collections.Generic;
using MakeClass.Attribute;
using MakeClass.Attribute;
using MakeClass.Attribute;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace MakeClass.Traits;

public class ExampleTrait : TraitBase
{
    protected override void Build()
    {
         var recipe = new RecipeBuilder()
                    .SetPattern("AAA", 3, 1)
                    .AddIngredient('A',
                        new CraftingRecipeIngredient
                            { Type = EnumItemClass.Item, Code = new AssetLocation("game", "stick") })
                    .SetOutput(new CraftingRecipeIngredient
                        { Type = EnumItemClass.Block, Code = new AssetLocation("game", "chair-blue") })
                    .Build();
        
        Builder
            .Code("example")
            .Name("ru", "Пример")
            .Type(EnumTraitType.Positive)
            .AddAttribute(new CharcoalPileDropRate(1))
            .AddAttribute(new StickDropRate(1))
            .AddAttribute(new TreeSeedDropRate(1))
            .AddAttribute(new WoodDropRate(1))
            .AddAttribute(new FruitTreeDropRate(1))
            .AddAttribute(new BowDrawingStrength(0.1))
            .AddAttribute(new RangedWeaponsSpeed(0.1))
            .AddAttribute(new RangedWeaponsAccuracy(0.1))
            .AddRecipe(recipe, new Dictionary<string, string>())
            .MakeRecipeExclusive(new AssetLocation("game", "pickaxe-tinbronze"));
    }
}
