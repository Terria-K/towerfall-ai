using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModLantern {
    public static StateEntity GetState(this Lantern ent) {
      var aiState = new StateFalling { type = Types.Lantern };
      ExtEntity.SetAiState(ent, aiState);
      aiState.falling = DynamicData.For(ent).Get<bool>("falling");
      return aiState;
    }
  }
}
