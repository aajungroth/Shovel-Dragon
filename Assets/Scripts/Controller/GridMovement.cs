using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour {
  // Starts the coroutine to move a transform in a direction
  public void MoveTransformInDirection(Vector2 direction, Action done,
  GameObject entity) {
    // The transform that will be moved on the view
    Transform targetTransform = entity.transform;

    // The time the transform will take to be moved
    float timeToMove = entity.GetComponent<EntityModel>().timeToMove;

    // The directoin the transform will moved in
    Vector3 transformDirection = Vector3.zero;

    // Converts from Vector2 to Vector 3
    if (direction == Vector2.down) {
      transformDirection = Vector3.down;
    }
    else if (direction == Vector2.left) {
      transformDirection = Vector3.left;
    }
    else if (direction == Vector2.right) {
      transformDirection = Vector3.right;
    }
    else if (direction == Vector2.up) {
      transformDirection = Vector3.up;
    }

    StartCoroutine(
      MoveTransform(transformDirection, done, targetTransform, timeToMove));
  }

  // Moves a transform in the requested time and direction and signals when
  // the movement is complete
  private IEnumerator MoveTransform(Vector3 direction, Action done,
  Transform targetTransform, float timeToMove) {
    // The position the transform is moving from
    Vector3 originalPosition = targetTransform.position;

    // The position the transform is moving to
    Vector3 targetPosition = originalPosition + direction;

    // The time that has passed during the move
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
