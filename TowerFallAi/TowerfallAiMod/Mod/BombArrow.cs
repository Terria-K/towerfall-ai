using System;
using Monocle;
using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModBombArrow {
    public static StateEntity GetState(this BombArrow ent) {
      var state = (StateArrow)ExtEntity.GetStateArrow(ent);
      state.timeLeft = (float)Math.Ceiling(DynamicData.For(ent).Get<Alarm>("explodeAlarm").FramesLeft);
      return state;
    }
  }
}
