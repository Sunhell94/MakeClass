using System.Collections.Generic;
using MakeClass.Internal;
using MakeClass.Traits.Value;
using MakeClass.Traits.Craft;
using Vintagestory.API.Common;

namespace MakeClass.Classes;

public abstract class CharacterClass
{
    private readonly List<TraitBase> _traits;
    private readonly List<AssetLocation> _gear;
    protected CharacterBuilder Builder = new();

    protected CharacterClass(List<TraitBase> traits, List<AssetLocation> gear)
    {
        _traits = traits;
        _gear = gear;
    }

    protected abstract void Build();

    public void Registry(Registry registry)
    {
        Build();
        foreach (var gear in _gear)
        {
            Builder.AddGear(gear);
        }
            
        foreach (var trait in _traits)
        {
            Builder.AddTrait(trait.Registry(registry));
        }
        Builder.Registry(registry);
    }
}
