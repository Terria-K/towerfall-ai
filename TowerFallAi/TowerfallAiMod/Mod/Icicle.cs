using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModIcicle {
    public static StateEntity GetState(this Icicle ent) {
      var aiState = new StateFalling { type = Types.Icicle };
      ExtEntity.SetAiState(ent, aiState);
      aiState.falling = DynamicData.For(ent).Get<bool>("falling");
      return aiState;
    }
  }
}
