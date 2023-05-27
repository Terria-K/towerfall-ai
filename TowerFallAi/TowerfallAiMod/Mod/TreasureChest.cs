using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;
using TowerfallAi.Common;

namespace TowerfallAi.Mod {
  public static class ModTreasureChest {
    public static StateEntity GetState(this TreasureChest ent) {
      if (ent.State == TreasureChest.States.WaitingToAppear) return null;

      var aiState = new StateChest { type = Types.Chest };
      ExtEntity.SetAiState(ent, aiState);
      aiState.state = ent.State.ToString().FirstLower();
      aiState.chestType = DynamicData.For(ent).Get<TreasureChest.Types>("type").ToString().FirstLower();

      return aiState;
    }
  }
}
