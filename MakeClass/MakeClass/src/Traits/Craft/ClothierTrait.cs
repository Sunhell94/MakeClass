using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class ClothierTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("clothier")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Специалист по одежде");
    }
}