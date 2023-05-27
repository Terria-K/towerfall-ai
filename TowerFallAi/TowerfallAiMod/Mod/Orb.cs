using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModOrb{
    public static StateEntity GetState(this Orb ent) {
      var aiState = new StateFalling { type = Types.Orb };
      ExtEntity.SetAiState(ent, aiState);
      aiState.falling = DynamicData.For(ent).Get<bool>("falling");
      return aiState;
    }
  }
}
