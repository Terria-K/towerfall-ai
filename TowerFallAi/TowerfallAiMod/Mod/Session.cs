using System;
using TowerFall;
using TowerfallAi.Common;
using TowerfallAi.Core;

namespace TowerfallAi.Mod {
  public class ModSession {
    public static void Load() 
    {
      On.TowerFall.Session.OnLevelLoadFinish += OnLevelLoadFinish_patch;
    }

    public static void Unload() 
    {
      On.TowerFall.Session.OnLevelLoadFinish -= OnLevelLoadFinish_patch;
    }

    private static void OnLevelLoadFinish_patch(On.TowerFall.Session.orig_OnLevelLoadFinish orig, Session self)
    {
      orig(self);

      if (AiMod.Enabled) {
        Agents.NotifyLevelLoad(self.CurrentLevel);
      }
    }
  }
}
