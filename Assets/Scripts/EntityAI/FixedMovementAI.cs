using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovementAI : EntityAI {
  public Vector2 direction = Vector2.right;

  public override EventModel GetEvent(GameObject entity, EventModel entityEvent,
  List<GameObject> entityList, string playerAbility, Vector2 playerDirection,
  TrackModel trackModel) {
    // Tests if moving in the current direction would be invalid
		if (!ValidateMovement.IsMoveValid(direction, entity, trackModel)) {
			// Flips the direction
      direction.x *= -1;
			direction.y *= -1;
		}

    if (direction == Vector2.down) {
      entityEvent.ability = AbilityModel.moveDown;
    }
    else if (direction == Vector2.left) {
      entityEvent.ability = AbilityModel.moveLeft;
    }
    else if (direction == Vector2.right) {
      entityEvent.ability = AbilityModel.moveRight;
    }
    else if (direction == Vector2.up) {
      entityEvent.ability = AbilityModel.moveUp;
    }

    entityEvent.direction = direction;
    entityEvent.endPosition = entityEvent.startPosition + direction;
    entityEvent.entity = entity;

    return entityEvent;
	}
}
