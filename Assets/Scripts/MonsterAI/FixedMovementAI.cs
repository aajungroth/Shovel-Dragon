using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovementAI : MonsterAI {
  public Vector2 direction = Vector2.right;

  public override Vector2 GetMove(List<EntityModel> entityList, TrackModel trackModel, EntityModel entity) {
    // Tests if moving in the current direction would be invalid
		if (!ValidateMovement.IsMoveValid(trackModel, entity, direction)) {
			// Flips the direction
      direction.x *= -1;
			direction.y *= -1;
		}

    return direction;
	}
}
