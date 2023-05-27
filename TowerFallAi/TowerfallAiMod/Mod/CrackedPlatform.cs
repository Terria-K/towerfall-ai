using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;
using TowerfallAi.Common;

namespace TowerfallAi.Mod {
  public static class ModCrackedPlatform {
    public static StateEntity GetState(this CrackedPlatform ent) {
      var state = new StateEntity { type = Types.CrackedPlatform };
      ExtEntity.SetAiState(ent, state);
      state.state = DynamicData.For(ent).Get<CrackedPlatform.States>("state").ToString().FirstLower();
      return state;
    }
  }
}
