using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour {
  // Starts the coroutine to move a transform in a direction
  public void MoveTransformInDirection(Action done, EventModel entityEvent) {
    Transform targetTransform = entityEvent.entity.transform;
    float timeToMove = entityEvent.entity
      .GetComponent<EntityModel>()
      .timeToMove;
    Vector3 direction = Vector3.zero;

    if (entityEvent.direction == Vector2.down) {
      direction = Vector3.down;
    }
    else if (entityEvent.direction == Vector2.left) {
      direction = Vector3.left;
    }
    else if (entityEvent.direction == Vector2.right) {
      direction = Vector3.right;
    }
    else if (entityEvent.direction == Vector2.up) {
      direction = Vector3.up;
    }

    StartCoroutine(
      MoveTransform(direction, done, targetTransform, timeToMove));
  }

  // Moves a transform in the requested time and direction and signals when
  // the movement is complete
  private IEnumerator MoveTransform(Vector3 direction, Action done,
  Transform targetTransform, float timeToMove) {
    Vector3 originalPosition = targetTransform.position;
    Vector3 targetPosition = originalPosition + direction;
    float timeElapsed = 0;

    // This performs the movement across multiple frames
    while (timeElapsed < timeToMove) {
      targetTransform.position = Vector3
        .Lerp(originalPosition, targetPosition, timeElapsed / timeToMove);
      timeElapsed += Time.deltaTime;
      yield return null;
    }

    // Ensures the GameObject reaches the target position exactly
    targetTransform.position = targetPosition;

    // Signals to the original caller that the coroutine is finished
    done();
  }
}
