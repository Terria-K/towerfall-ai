using Microsoft.Xna.Framework;
using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;
using TowerfallAi.Common;

namespace TowerfallAi.Mod {
  public static class ModShiftBlock {
    public static StateEntity GetState(this ShiftBlock ent) {
      var aiState = new StateShiftBlock { type = Types.ShiftBlock };
      ExtEntity.SetAiState(ent, aiState);
      var entity = DynamicData.For(ent);
      var startPosition = entity.Get<Vector2>("startPosition");
      var node = entity.Get<Vector2>("node");
      aiState.startPosition = new Vec2 {
        x = startPosition.X,
        y = startPosition.Y
      };

      aiState.endPosition = new Vec2 {
        x = node.X,
        y = node.Y
      };

      aiState.state = ((ShiftBlock.States)Util.GetPrivateFieldValue("state", ent)).ToString().FirstLower();
      return aiState;
    }
  }
}
