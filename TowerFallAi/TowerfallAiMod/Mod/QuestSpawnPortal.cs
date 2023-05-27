using System.Reflection;
using TowerFall;
using TowerfallAi.Api;
using TowerfallAi.Common;

namespace TowerfallAi.Mod {
  public static class ModQuestSpawnPortal {
    public static StateEntity GetState(this QuestSpawnPortal ent) {
      if (!(bool)Util.GetFieldValue("appeared", typeof(QuestSpawnPortal), ent, BindingFlags.Instance | BindingFlags.NonPublic)) {
        return null;
      }

      var aiState = new StateEntity {
        type = "portal",
      };

      ExtEntity.SetAiState(ent, aiState);
      return aiState;
    }
  }
}
