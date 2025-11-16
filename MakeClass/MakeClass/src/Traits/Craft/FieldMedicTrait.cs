using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class FieldMedicTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("fieldmedic")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Медик")
            .MakeRecipeExclusive(new AssetLocation("game", "poultice-linen-honey-sulfur"))
            .MakeRecipeExclusive(new AssetLocation("game", "poultice-reed-honey-sulfur"))
            .MakeRecipeExclusive(new AssetLocation("game", "bandage-clean"));
    }
} 
