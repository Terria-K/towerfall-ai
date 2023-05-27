using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModSwitchBlock {
    public static StateEntity GetState(this SwitchBlock ent) {
      var aiState = new StateSwitchBlock { type = Types.SwitchBlock };

      ExtEntity.SetAiState(ent, aiState);
      aiState.collidable = ent.Collidable;
      aiState.warning = DynamicData.For(ent).Get<bool>("drawFlicker") || ent.DrawWarning > 0;

      return aiState;
    }
  }
}
