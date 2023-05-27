using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Monocle;
using TowerFall;
using TowerfallAi.Api;
using TowerfallAi.Common;
using TowerfallAi.Core;

namespace TowerfallAi.Mod {
  public static class ModPlayer
  {
    public static StateEntity GetState(this Player ent) {
      var aiState = new StateArcher() { type = "archer" };

      ExtEntity.SetAiState(ent, aiState);
      aiState.playerIndex = ent.PlayerIndex;
      aiState.shield = ent.HasShield;
      aiState.wing = ent.HasWings;
      aiState.state = ent.State.ToString().FirstLower();
      aiState.arrows = new List<string>();
      List<ArrowTypes> arrows = ent.Arrows.Arrows;
      for (int i = 0; i < arrows.Count; i++) {
        aiState.arrows.Add(arrows[i].ToString().FirstLower());
      }
      aiState.canHurt = ent.CanHurt;
      aiState.dead = ent.Dead;
      aiState.facing = (int)ent.Facing;
      aiState.onGround = ent.OnGround;
      aiState.onWall = CanWallJump(ent, Facing.Left) || CanWallJump(ent, Facing.Right);
      Vector2 aim = Calc.AngleToVector(ent.AimDirection, 1);
      aiState.aimDirection = new Vec2 {
        x = aim.X,
        y = -aim.Y
      };
      aiState.team = AgentConfigExtension.GetTeam(ent.TeamColor);

      return aiState;
    }
    private static bool CanWallJump(Player self, Facing dir)
    {
      return !self.HasWings && !self.CollideCheck(GameTags.Solid, self.Position + Vector2.UnitY * 5f) && self.CollideCheck(GameTags.Solid, WrapMath.Vec(self.X + (float)((Facing)(2 * (int)dir)), self.Y));
    }
  }
}
