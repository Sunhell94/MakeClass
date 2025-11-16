using System;
using System.Collections.Generic;
using System.Linq;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace MakeClass.Internal;

public class CharacterBuilder
{
    private Dictionary<string, HashSet<Translation>> _translations = new();

    private CharacterClass _class = new CharacterClass()
    {
        Gear = Array.Empty<JsonItemStack>(),
        Traits = Array.Empty<string>(),
    };

    public CharacterBuilder Code(string code)
    {
        _class.Code = code;
        return this;
    }

    public CharacterBuilder AddGear(AssetLocation gearCode)
    {
        _class.Gear = _class.Gear.Concat(new JsonItemStack[]
        {
            new()
            {
                Type = EnumItemClass.Item,
                Code = gearCode
            }
        }).ToArray();
        return this;
    }

    public CharacterBuilder AddTrait(Trait trait)
    {
        _class.Traits = _class.Traits.Concat(new[] { trait.Code }).ToArray();
        return this;
    }

    public CharacterBuilder AddTrait(string code)
    {
        _class.Traits = _class.Traits.Concat(new[] { code }).ToArray();
        return this;
    }
    
    public CharacterBuilder Name(string locale, string translation)
    {
        if (string.IsNullOrEmpty(_class.Code))
        {
            throw new InvalidOperationException("Code must be set.");
        }

        var tr = new Translation($"characterclass-{_class.Code}", translation);
        AddTranslation(locale, tr);
        return this;
    }


    public CharacterBuilder Description(string locale, string translation)
    {
        if (string.IsNullOrEmpty(_class.Code))
        {
            throw new InvalidOperationException("Code must be set.");
        }

        var tr = new Translation($"characterdesc-{_class.Code}", translation);
        AddTranslation(locale, tr);
        return this;
    }

    public void Registry(Registry registry)
    {
        if (string.IsNullOrEmpty(_class.Code))
        {
            throw new InvalidOperationException("Code must be set.");
        }

        registry.RegisterCharacter(_class, _translations);
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
}