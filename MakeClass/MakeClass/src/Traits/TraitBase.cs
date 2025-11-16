using MakeClass.Internal;
using Vintagestory.GameContent;

namespace MakeClass.Traits;

public abstract class TraitBase
{
    protected readonly TraitBuilder Builder = new();

    protected abstract void Build();

    public Trait Registry(Registry registry)
    {
        Build();
        return Builder.Registry(registry);
    }
}
