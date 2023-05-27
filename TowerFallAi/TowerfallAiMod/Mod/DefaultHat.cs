using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModDefaultHat{
    public static StateEntity GetState(this DefaultHat ent) {
      var aiState = new StateHat { type = Types.Hat };
     
      aiState.playerIndex = ent.PlayerIndex;
      ExtEntity.SetAiState(ent, aiState);
      return aiState;
    }
  }
}
