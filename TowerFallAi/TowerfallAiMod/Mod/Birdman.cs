using System.Reflection;
using Monocle;
using TowerFall;
using TowerfallAi.Api;
using TowerfallAi.Common;

namespace TowerfallAi.Mod {
  public static class ModBirdman {
    const int ST_IDLE = 0;
    const int ST_ATTACK = 1;
    public static StateEntity GetState(this Birdman ent) {
      var aiState = new StateEntity { type = "birdman" };

      if ((Counter)Util.GetFieldValue("attackCooldown", typeof(Birdman), ent, BindingFlags.NonPublic | BindingFlags.Instance) 
          && !(bool)Util.GetFieldValue("canArrowAttack", typeof(Birdman), ent, BindingFlags.NonPublic | BindingFlags.Instance)) {
        aiState.state = "resting";
      } else {
        switch (ent.State) {
          case ST_IDLE:
            aiState.state = "idle";
            break;
          case ST_ATTACK:
            aiState.state = "attack";
            break;
        }
      }
      
      ExtEntity.SetAiState(ent, aiState);
      return aiState;
    }
  }
}
