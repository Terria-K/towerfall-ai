using System;
using FortRise;
using Microsoft.Xna.Framework.Graphics;
using TowerfallAi.Core;
using TowerfallAi.Mod;

namespace TowerfallAi;

[Fort("com.vcanaa.TowerFallAi", "TowerFallAI")]
public sealed class TowerFallAiModule : FortModule
{
    public override void Load()
    {
        AiMod.ParseArgs(null);
        RiseCore.DisallowInputReplacement = true;
        RiseCore.Events.OnPreInitialize += OnPreInitialize;
        RiseCore.Events.OnPostInitialize += OnPostInitialize;
        RiseCore.Events.OnAfterRender += OnAfterRender;
        ModLevel.Load();
        ModMenuInput.Load();
        ModPauseMenu.Load();
        ModSession.Load();
        ModTFGame.Load();
    }

    private void OnAfterRender(SpriteBatch obj)
    {
        obj.Begin();
        Agents.Draw();
        obj.End();
    }

    private void OnPreInitialize()
    {
        AiMod.PreGameInitialize();
    }

    private void OnPostInitialize()
    {
        AiMod.PostGameInitialize();
    }

    public override void Unload()
    {
        RiseCore.Events.OnAfterRender -= OnAfterRender;
        RiseCore.Events.OnPreInitialize -= OnPreInitialize;
        RiseCore.Events.OnPostInitialize -= OnPostInitialize;
        ModLevel.Unload();
        ModMenuInput.Unload();
        ModPauseMenu.Unload();
        ModSession.Unload();
        ModTFGame.Unload();
    }
}