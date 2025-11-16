using Vintagestory.API.Common;

namespace MakeClass.Config;

public class Config
{
    private const string CfgFileName = "makeclass.json";
    public bool DisableVanillaClasses = true;

    public static Config Load(ICoreAPI api)
    {
        var loaded = api.LoadModConfig<Config>(CfgFileName);
        if (loaded != null)
        {
            return loaded;
        }

        var cfg = new Config();
        api.StoreModConfig(new Config(), CfgFileName);
        return cfg;
    }
}