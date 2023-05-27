using Monocle;
using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModCrackedWall{
    public static StateEntity GetState(this CrackedWall ent) {
      var state = new StateCrackedWall { type = Types.CrackedWall };
      ExtEntity.SetAiState(ent, state);
      state.count = DynamicData.For(ent).Get<float>("explodeCounter");
      return state;
    }
  }
}
