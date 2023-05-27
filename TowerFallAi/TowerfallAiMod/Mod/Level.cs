using System;
using System.Reflection;
using System.Xml;
using MonoMod.RuntimeDetour;
using TowerFall;
using TowerfallAi.Core;

namespace TowerfallAi.Mod
{
  public static class ModLevel 
  {
    private static IDetour hook_HandlePausing;
    public static void Load() 
    {
      hook_HandlePausing = new Hook(
        typeof(Level).GetMethod("HandlePausing", BindingFlags.Instance | BindingFlags.NonPublic),
        HandlePausing_patch
      );
      On.TowerFall.Level.Update += Update_patch;
    }

    public static void Unload() 
    {
      On.TowerFall.Level.Update -= Update_patch;
    }

    private static void Update_patch(On.TowerFall.Level.orig_Update orig, Level self)
    {
      if (AiMod.Enabled)
        Agents.RefreshInputFromAgents(self);
      
      orig(self);
    }

    private delegate void orig_HandlePausing(Level self);

    private static void HandlePausing_patch(orig_HandlePausing orig, Level self) 
    {
			if (AiMod.Enabled && !AiMod.IsHumanPlaying()) {
        return;
      }

      orig(self);
    }
  }
}
