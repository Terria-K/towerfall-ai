using System;
using Monocle;
using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;
using TowerfallAi.Common;

namespace TowerfallAi.Mod {
  public static class ModSuperBombArrow {
    public static StateEntity GetState(this SuperBombArrow ent) {
      var aiState = new StateArrow { type = Types.Arrow };

      ExtEntity.SetAiState(ent, aiState);
      aiState.state = ent.State.ToString().FirstLower();
      aiState.arrowType = ent.ArrowType.ToString().FirstLower();
      aiState.timeLeft = (int)Math.Ceiling(DynamicData.For(ent).Get<Alarm>("explodeAlarm").FramesLeft);

      return aiState;
    }
  }
}
