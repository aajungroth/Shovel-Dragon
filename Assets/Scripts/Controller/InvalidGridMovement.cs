using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidGridMovement : MonoBehaviour {
  // Starts the coroutine to feint a transform in a direction
  public void FeintTransformInDirection(Action done, EventModel entityEvent) {
    Transform targetTransform = entityEvent.entity.transform;
    float timeToMove = entityEvent.entity
      .GetComponent<EntityModel>()
      .timeToMove;
    Vector3 direction = Vector3.zero;

    if (entityEvent.direction == Vector2.down) {
      direction = new Vector3(0, -0.5f, 0);
    }
    else if (entityEvent.direction == Vector2.left) {
      direction = new Vector3(-0.5f, 0, 0);
    }
    else if (entityEvent.direction == Vector2.right) {
      direction = new Vector3(0.5f, 0, 0);
    }
    else if (entityEvent.direction == Vector2.up) {
      direction = new Vector3(0, 0.5f, 0);
    }

    StartCoroutine(
      FeintTransform(direction, done, targetTransform, timeToMove));
  }

  // Feints a transform in the requested time and direction and signals when
  // the movement is complete
  private IEnumerator FeintTransform(Vector3 direction, Action done,
  Transform targetTransform, float timeToMove) {
    Vector3 originalPosition = targetTransform.position;
    Vector3 targetPosition = originalPosition + direction;
    float timeElapsed = 0;

    bool firstHalfInProgress = true;

    // This performs the first half of the feint across multiple frames
    while (firstHalfInProgress && timeElapsed < timeToMove) {
      targetTransform.position = Vector3
        .Lerp(originalPosition, targetPosition, timeElapsed / timeToMove);
      yield return null;
    }

    // Tests if the first first half of the feint completed
    if (firstHalfInProgress && timeElapsed == timeToMove) {
      // Allows the coroutine to progress to the next half of the feint
      firstHalfInProgress = false;

      // Ensures the GameObject reaches the target position exactly
      targetTransform.position = targetPosition;

      // Doubles the time to move to create time for the second half
      timeToMove *= 2;
    }

    // This performs the second half of the fient across multiple frames
    while (timeElapsed < timeToMove) {
      targetTransform.position = Vector3
        .Lerp(targetPosition, originalPosition, timeElapsed / timeToMove);
      yield return null;
    }

    // Ensures the GameObject reaches the original position exactliy
    targetTransform.position = originalPosition;

    // Signals to the original caller that the coroutine is finished
    done();
  }
}
