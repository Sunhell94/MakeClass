using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Vintagestory.API.Common;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

namespace MakeClass.Internal;

public class Registry
{
    private readonly Dictionary<string, HashSet<Translation>> _translations = new();
    public ImmutableList<CharacterClass> CharacterClasses { get; private set; } = ImmutableList<CharacterClass>.Empty;
    public ImmutableList<Trait> Traits { get; private set; } = ImmutableList<Trait>.Empty;

    public ICoreAPI Api;

    private string _path;

    public Registry(string path, ICoreAPI api)
    {
        _path = path;
        Api = api;
    }

    public void RegisterCharacter(CharacterClass character, Dictionary<string, HashSet<Translation>> translations)
    {
        CharacterClasses = CharacterClasses.Add(character);
        AddTranslation(translations);
    }

    public void RegisterTrait(Trait trait, Dictionary<string, HashSet<Translation>> translations)
    {
        Traits = Traits.Add(trait);
        AddTranslation(translations);
    }

    private void AddTranslation(Dictionary<string, HashSet<Translation>> translations)
    {
        foreach (var trPair in translations)
        {
            var exists = _translations.TryGetValue(trPair.Key, out var hashSet);
            if (!exists)
            {
                hashSet = trPair.Value;
                _translations.Add(trPair.Key, hashSet);
            }

            hashSet.AddRange(trPair.Value);
        }
    }

    /// <summary>
    /// Save localization file to ModData/{modid}/lang
    /// </summary>
    public void SaveTranslation()
    {
        foreach (var trPair in _translations)
        {
            var path = $"{_path}/ModData/makeclass/lang";

            Directory.CreateDirectory(path);
            var file = File.Create($"{path}/{trPair.Key}.json");

            var dict = trPair.Value.ToDictionary(tr => tr.Key, tr => tr.Body);
            var json = JsonConvert.SerializeObject(dict);
            file.Write(Encoding.UTF8.GetBytes(json));

            // file.Flush();
            file.Close();
        }
    }
}