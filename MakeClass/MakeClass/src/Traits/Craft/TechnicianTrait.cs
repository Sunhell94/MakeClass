using System.Collections.Generic;
using MakeClass.Internal;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MakeClass.Traits.Craft;

public class TechnicianTrait : TraitBase
{
    protected override void Build()
    {
        Builder
            .Code("technician")
            .Type(EnumTraitType.Positive)
            .Name("ru", "Техник")
            .MakeRecipeExclusive(new AssetLocation("electricalprogressivebasics", "coil"))
            .MakeRecipeExclusive(new AssetLocation("electricalprogressivebasics", "engineshaft"))
            .MakeRecipeExclusive(new AssetLocation("electricalprogressivebasics", "emotor-tier1-stator"))
            .MakeRecipeExclusive(new AssetLocation("electricalprogressivebasics", "egenerator-tier1-stator"))
            .MakeRecipeExclusive(new AssetLocation("electricalprogressivebasics", "etermogenerator-south"))
            .MakeRecipeExclusive(new AssetLocation("electricalprogressivebasics", "switch-enabled"))
            .MakeRecipeExclusive(new AssetLocation("electricalprogressivebasics", "termoplastini"))
            .MakeRecipeExclusive(new AssetLocation("electricalprogressiveqol", "charger-disabled-south"))
            .MakeRecipeExclusive(new AssetLocation("electricalprogressiveqol", "efreezer2-melted-north"))
            .MakeRecipeExclusive(new AssetLocation("electricalprogressiveqol", "eoven-disabled-north"))
            .MakeRecipeExclusive(new AssetLocation("electricalprogressiveqol", "estove-disabled-south"))
            .MakeRecipeExclusive(new AssetLocation("vinteng", "velvgenerator-north"))
            .MakeRecipeExclusive(new AssetLocation("vinteng", "velvbattery"))
            .MakeRecipeExclusive(new AssetLocation("vinteng", "vekiln-north"))
            .MakeRecipeExclusive(new AssetLocation("vinteng", "veforge-north"))
            .MakeRecipeExclusive(new AssetLocation("vinteng", "velvek-motor-north"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-arquebus-iron"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-arquebus-meteoriciron"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-blunderbuss-iron"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-blunderbuss-meteoriciron"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-blunderbuss-steel"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "barrel-blunderbuss-steel"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-carbine-steel"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "barrel-carbine-steel"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-musket-steel"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "barrel-musket-steel"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-pistol-tinbronze"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-pistol-bismuthbronze"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-pistol-blackbronze"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "barrel-pistol-steel"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-pistol-steel"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-superimposed-tinbronze"))
            .MakeRecipeExclusive(new AssetLocation("maltiezfirearms", "firearm-superimposed-bismuthbronze"));
    }
} 
