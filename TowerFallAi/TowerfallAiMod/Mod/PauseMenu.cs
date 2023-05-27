using System.Reflection;
using Microsoft.Xna.Framework;
using MonoMod.RuntimeDetour;
using TowerFall;
using TowerfallAi.Common;
using TowerfallAi.Core;

namespace TowerfallAi.Mod {
  public class ModPauseMenu : PauseMenu {
    private static IDetour hook_VersusMatchSettingsAndSave;
    private static IDetour hook_Quit;
    private static IDetour hook_QuitAndSave;
    private static IDetour hook_QuestMap;
    private static IDetour hook_QuestMapAndSave;
    private static IDetour hook_QuestRestart;
    private static IDetour hook_VersusRematch;
    private static IDetour hook_VersusArcherSelect;
    private static IDetour hook_VersusMatchSettings;

    public ModPauseMenu(Level level, Vector2 position, MenuType menuType, int controllerDisconnected = -1) : base(level, position, menuType, controllerDisconnected) { }

    public static void Load() 
    {
      BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
      hook_VersusMatchSettingsAndSave = new Hook(
        typeof(PauseMenu).GetMethod("VersusMatchSettingsAndSave", flags),
        EndSession
      );
      hook_Quit = new Hook(
        typeof(PauseMenu).GetMethod("Quit", flags),
        EndSession
      );
      hook_QuitAndSave = new Hook(
        typeof(PauseMenu).GetMethod("QuitAndSave", flags),
        EndSession
      );
      hook_QuestMap = new Hook(
        typeof(PauseMenu).GetMethod("QuestMap", flags),
        EndSession
      );
      hook_QuestMapAndSave = new Hook(
        typeof(PauseMenu).GetMethod("QuestMapAndSave", flags),
        EndSession
      );
      hook_VersusMatchSettings = new Hook(
        typeof(PauseMenu).GetMethod("VersusMatchSettings", flags),
        EndSession
      );
      hook_VersusArcherSelect = new Hook(
        typeof(PauseMenu).GetMethod("VersusArcherSelect", flags),
        EndSession
      );
      hook_QuestRestart = new Hook(
        typeof(PauseMenu).GetMethod("QuestRestart", flags),
        Rematch
      );
      hook_VersusRematch = new Hook(
        typeof(PauseMenu).GetMethod("VersusRematch", flags),
        Rematch
      );
    }

    public static void Unload() 
    {
      hook_VersusMatchSettingsAndSave.Dispose();
      hook_Quit.Dispose();
      hook_QuitAndSave.Dispose();
      hook_QuestMapAndSave.Dispose();
      hook_QuestMap.Dispose();
      hook_VersusArcherSelect.Dispose();
      hook_VersusMatchSettings.Dispose();
      hook_VersusRematch.Dispose();
      hook_QuestRestart.Dispose();
    }

    private delegate void orig_EndSession(PauseMenu self);

    private static void EndSession(orig_EndSession orig, PauseMenu self) 
    {
      if (AiMod.Enabled) 
      {
        AiMod.EndSession();
        return;
      }
      orig(self);
    }

    private delegate void orig_Rematch(PauseMenu self);

    private static void Rematch(orig_Rematch orig, PauseMenu self) 
    {
      if (AiMod.Enabled) 
      {
        AiMod.Rematch();
        return;
      }
      orig(self);
    }
  }
}
