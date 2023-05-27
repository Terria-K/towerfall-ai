using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModCultist {
    public static StateEntity GetState(this Cultist ent) {
      var aiState = new StateEntity();

      aiState.type = ConversionTypes.CultistTypes.GetB(DynamicData.For(ent).Get<Cultist.CultistTypes>("type"));
      ExtEntity.SetAiState(ent, aiState);
      return aiState;
    }
  }
}
