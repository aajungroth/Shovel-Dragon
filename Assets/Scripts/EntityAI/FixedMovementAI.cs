using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovementAI : EntityAI {
  public Vector2 direction = Vector2.right;

  // Moves the entity on the X or Y axis based on the direction
  public override (string, Vector2) GetEvent(GameObject entity,
  List<GameObject> entityList, string playerAbility, Vector2 playerDirection,
  TrackModel trackModel) {
    // The ability that the entity will perform
    string ability = AbilityModel.none;

    // Tests if moving in the current direction would be invalid
		if (!ValidateMovement.IsMoveValid(direction, entity, trackModel)) {
			// Flips the direction
      direction.x *= -1;
			direction.y *= -1;
		}

    // Gets the ability name based on the direction
    if (direction == Vector2.down) {
      ability = AbilityModel.moveDown;
    }
    else if (direction == Vector2.left) {
      ability = AbilityModel.moveLeft;
    }
    else if (direction == Vector2.right) {
      ability = AbilityModel.moveRight;
    }
    else if (direction == Vector2.up) {
      ability = AbilityModel.moveUp;
    }

    return (ability, direction);
	}
}
