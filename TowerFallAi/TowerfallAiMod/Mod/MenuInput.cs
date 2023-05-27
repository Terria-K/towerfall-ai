using System;
using Monocle;
using MonoMod.RuntimeDetour;
using TowerFall;
using TowerfallAi.Core;

namespace TowerfallAi.Mod {
  public static class ModMenuInput {
    // static ModMenuInput() {
    //   // TODO Use IL Patch
    //   if (!AiMod.Enabled) {
    //     // Avoid overriding menu inputs created by the mod.
    //     MenuInput.MenuInputs = new PlayerInput[0];
    //   }
    //   MenuInput.repeatLeftCounter = new Counter();
    //   MenuInput.repeatRightCounter = new Counter();
    //   MenuInput.repeatUpCounter = new Counter();
    //   MenuInput.repeatDownCounter = new Counter();
    // }

    private static IDetour hook_Confirm;
    private static IDetour hook_ConfirmOrStart;

    public static void Load() 
    {
      hook_Confirm = new Hook(
        typeof(MenuInput).GetProperty("Confirm").GetGetMethod(),
        Confirm_patch
      );
      hook_ConfirmOrStart = new Hook(
        typeof(MenuInput).GetProperty("ConfirmOrStart").GetGetMethod(),
        ConfirmOrStart_patch
      );
    }

    public static void Unload() 
    {
      hook_Confirm.Dispose();
      hook_ConfirmOrStart.Dispose();
    }

    public delegate bool orig_Confirm();
    public delegate bool orig_ConfirmOrStart();

    public static bool Confirm_patch(orig_Confirm orig) 
    {
      if (AiMod.Enabled && !AiMod.IsHumanPlaying()) return true;
      return orig();
    }

    public static bool ConfirmOrStart_patch(orig_ConfirmOrStart orig) 
    {
      if (AiMod.Enabled && !AiMod.IsHumanPlaying()) return true;
      return orig();
    }
  }
}
