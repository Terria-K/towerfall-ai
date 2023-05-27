using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModBat {
    public static StateEntity GetState(this Bat ent) {
      var aiState = new StateEntity();

      aiState.type = ConversionTypes.BatTypes.GetB(DynamicData.For(ent).Get<Bat.BatType>("batType"));
      ExtEntity.SetAiState(ent, aiState);
      return aiState;
    }
  }
}
