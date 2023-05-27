using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using MonoMod.RuntimeDetour;
using TowerFall;
using TowerfallAi.Core;

namespace TowerfallAi.Mod {
  public static class ModTFGame {

    private static IDetour hook_Update;

    public static void Load() 
    {
      hook_Update = new Hook(
        typeof(TFGame).GetMethod("Update", BindingFlags.Instance | BindingFlags.NonPublic),
        Update_patch
      );
    }

    public static void Unload() 
    {
      hook_Update.Dispose();
    }

    public delegate void orig_Update(TFGame self, GameTime gameTime);

    public static void Update_patch(orig_Update orig, TFGame self, GameTime gameTime) 
    {
      if (!AiMod.Enabled)
      {
        orig(self, gameTime);
        return;
      }
      AiMod.Update(orig, self, gameTime);
    }

    // public ModTFGame(bool noIntro) : base(noIntro) {
    //   var ptr = typeof(TFGame).GetMethod("$original_Initialize").MethodHandle.GetFunctionPointer();
    //   originalInitialize = (Action)Activator.CreateInstance(typeof(Action), this, ptr);

    //   ptr = typeof(TFGame).GetMethod("$original_Update").MethodHandle.GetFunctionPointer();
    //   originalUpdate = (Action<GameTime>)Activator.CreateInstance(typeof(Action<GameTime>), this, ptr);

    //   if (AiMod.Enabled) {
    //     this.InactiveSleepTime = new TimeSpan(0);

    //     if (AiMod.IsFastrun) {
    //       Monocle.Engine.Instance.Graphics.SynchronizeWithVerticalRetrace = false;
    //       this.IsFixedTimeStep = false;
    //     } else {
    //       this.IsFixedTimeStep = true;
    //     }
    //   }
    // }

    // public override void Update(GameTime gameTime) {
    //   if (!AiMod.Enabled) {
    //     originalUpdate(gameTime);
    //     return;
    //   }

    //   AiMod.Update(originalUpdate);
    // }

    // public override void Draw(GameTime gameTime) {
    //   if (!AiMod.Enabled) {
    //     base.Draw(gameTime);
    //     return;
    //   }

    //   if (!AiMod.IsMatchRunning() || AiMod.NoGraphics) {
    //     Monocle.Engine.Instance.GraphicsDevice.SetRenderTarget(null);
    //     return;
    //   }
    //   base.Draw(gameTime);
    //   Monocle.Draw.SpriteBatch.Begin();
    //   Agents.Draw();
    //   Monocle.Draw.SpriteBatch.End();
    // }
  }
}
