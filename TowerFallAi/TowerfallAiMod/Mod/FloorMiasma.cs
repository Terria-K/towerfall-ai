using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModFloorMiasma {
    public static StateEntity GetState(this FloorMiasma ent) {
      var state = DynamicData.For(ent).Get<FloorMiasma.States>("state");
      if (state == FloorMiasma.States.Invisible) return null;

      var aiState = new StateEntity { type = Types.FloorMiasma };
      
      if (state == FloorMiasma.States.Dangerous) {
        aiState.canHurt = true;
      }

      ExtEntity.SetAiState(ent, aiState);
      return aiState;
    }
  }
}
