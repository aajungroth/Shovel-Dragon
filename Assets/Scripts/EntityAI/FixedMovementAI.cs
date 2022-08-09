using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovementAI : EntityAI {
  public Vector2 direction = Vector2.right;

  public override Vector2 GetDirection(string ability, EntityModel entity,
  List<GameObject> entityList, TrackModel trackModel) {
    // Tests if moving in the current direction would be invalid
		if (!ValidateMovement.IsMoveValid(direction, entity, trackModel)) {
			// Flips the direction
      direction.x *= -1;
			direction.y *= -1;
		}

    return direction;
	}
}
