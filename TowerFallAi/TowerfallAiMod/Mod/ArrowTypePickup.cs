using Monocle;
using MonoMod.Utils;
using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModArrowTypePickup {
    public static StateEntity GetState(this Entity ent) {
      var item = ent as ArrowTypePickup;
      var state = new StateItem {
        type = Types.Item,
        itemType = "arrow" + DynamicData.For(item).Get<ArrowTypes>("arrowType").ToString()
      };
      ExtEntity.SetAiState(ent, state);
      return state;
    }
  }
}
