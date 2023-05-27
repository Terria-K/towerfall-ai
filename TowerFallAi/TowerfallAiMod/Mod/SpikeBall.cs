using Microsoft.Xna.Framework;
using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModSpikeball {
    public static StateEntity GetState(this Spikeball ent) {
      var aiState = new StateSpikeBall { type = Types.SpikeBall };

      ExtEntity.SetAiState(ent, aiState);
      var entity = DynamicData.For(ent);
      var pivot = entity.Get<Vector2>("pivot");
      aiState.center = new Vec2 {
        x = pivot.X,
        y = pivot.Y
      };

      aiState.radius = entity.Get<float>("radius");

      return aiState;
    }
  }
}
