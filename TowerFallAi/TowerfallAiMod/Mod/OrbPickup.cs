using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModOrbPickup{
    public static StateEntity GetState(this OrbPickup ent) {
      var aiState = new StateItem { type = Types.Item };
      ExtEntity.SetAiState(ent, aiState);
      aiState.itemType = "orb" + DynamicData.For(ent).Get<OrbPickup.OrbTypes>("orbType").ToString();
      return aiState;
    }
  }
}
