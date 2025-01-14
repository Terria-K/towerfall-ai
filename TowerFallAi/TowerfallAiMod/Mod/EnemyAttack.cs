﻿using TowerFall;
using TowerfallAi.Api;

namespace TowerfallAi.Mod {
  public static class ModEnemyAttack {
    public static StateEntity GetState(this EnemyAttack ent) {
      var aiState = new StateEntity {
        type = "enemyAttack",
      };

      ExtEntity.SetAiState(ent, aiState);
      aiState.canHurt = true;
      return aiState;
    }
  }
}
