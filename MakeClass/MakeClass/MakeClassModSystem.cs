using HarmonyLib;
using MakeClass.Classes;
using MakeClass.Internal;
using ProtoBuf;
using Vintagestory.API.Client;
using Vintagestory.API.Server;
using Vintagestory.API.Config;
using Vintagestory.API.Common;

namespace MakeClass;

public class MakeClassModSystem : ModSystem
{
    private Harmony _harmony;
    private Registry _registry;
    public static ICoreAPI Api { get; private set; }

    public override void Start(ICoreAPI api)
    {
        Api = api;
    }
    
    private void Register(ICoreAPI api)
    {
        // НЕ ТРОГАТЬ НИКОГДА В ЖИЗНИ НАХУЙ ВАЩЕ!!!!
        // Руки нахуй оторву
        _registry = new Registry(api.DataBasePath, api);
        var cfg = Config.Config.Load(api);
        Patcher.Config = cfg;
        Patcher.Registry = _registry;
        _harmony = new Harmony(Mod.Info.ModID);
        _harmony.PatchAll();
        // Конец

        new RangerClass().Registry(_registry);
        new MinerClass().Registry(_registry);
        new CitizenClass().Registry(_registry);
        new MercenaryClass().Registry(_registry);
        new CraftsmanClass().Registry(_registry);
        new PeasantClass().Registry(_registry);
        new ForesterClass().Registry(_registry);
        new ExplorerClass().Registry(_registry);
        _registry.SaveTranslation();
    }

    public override void StartClientSide(ICoreClientAPI api) => Register(api);

    public override void StartServerSide(ICoreServerAPI api)
    {
        Register(api);
        var harmony = new Harmony("makeclass.recipefilter");
        RecipeAccess.Install(api, harmony);
    }

    public override void Dispose()
    {
        _harmony?.UnpatchAll(Mod.Info.ModID);
    }
}