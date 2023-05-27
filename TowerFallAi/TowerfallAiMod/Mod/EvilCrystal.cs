using TowerFall;
using TowerfallAi.Api;
using TowerfallAi.Common;

namespace TowerfallAi.Mod {
  public static class ModEvilCrystal {
    public static StateEntity GetState(this EvilCrystal ent) {
      var aiState = new StateSubType { type = "evilCrystal" };
      ExtEntity.SetAiState(ent, aiState);
      aiState.subType = ConversionTypes.CrystalTypes.GetB((EvilCrystal.CrystalColors)Util.GetPrivateFieldValue("crystalColor", ent));
      return aiState;
    }
  }
}
