using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidGridMovement : MonoBehaviour {
  // Starts the coroutine to feint a transform in a direction
  public void FeintTransformInDirection(Vector2 direction, Action done,
  GameObject entity) {
    // The transform that will be moved on the view
    Transform targetTransform = entity.transform;
    
    // The time the transform will take to be moved
    float timeToMove = entity.GetComponent<EntityModel>().timeToMove;
    
    // The direction the transform will be moved in
    Vector3 transformDirection = Vector3.zero;

    // Converts from Vector2 to Vector3
    if (direction == Vector2.down) {
      transformDirection = new Vector3(0, -0.5f, 0);
    }
    else if (direction == Vector2.left) {
      transformDirection = new Vector3(-0.5f, 0, 0);
    }
    else if (direction == Vector2.right) {
      transformDirection = new Vector3(0.5f, 0, 0);
    }
    else if (direction == Vector2.up) {
      transformDirection = new Vector3(0, 0.5f, 0);
    }

    StartCoroutine(
      FeintTransform(transformDirection, done, targetTransform, timeToMove));
  }

  // Feints a transform in the requested time and direction and signals when
  // the movement is complete
  private IEnumerator FeintTransform(Vector3 direction, Action done,
  Transform targetTransform, float timeToMove) {
    // The position the transform is being moved from
    Vector3 originalPosition = targetTransform.position;
    
    // The position the transform is being moved to
    Vector3 targetPosition = originalPosition + direction;

    // The time that has passed during the feint
    float timeElapsed = 0;

    // Tracks if the first half of the feint has been completed
    bool firstHalfInProgress = true;

    // This performs the first half of the feint across multiple frames
    while (firstHalfInProgress && timeElapsed < timeToMove) {
      targetTransform.position = Vector3
        .Lerp(originalPosition, targetPosition, timeElapsed / timeToMove);
      timeElapsed += Time.deltaTime;
      yield return null;
    }

    // Tests if the first first half of the feint completed
    if (firstHalfInProgress) {
      // Allows the coroutine to progress to the next half of the feint
      firstHalfInProgress = false;

      // Doubles the time to move to create time for the second half
      timeToMove *= 2;
    }

    // This performs the second half of the fient across multiple frames
    while (timeElapsed < timeToMove) {
      targetTransform.position = Vector3
        .Lerp(targetPosition, originalPosition, timeElapsed / timeToMove);
      timeElapsed += Time.deltaTime;
      yield return null;
    }

    // Ensures the GameObject reaches the original position exactliy
    targetTransform.position = originalPosition;

    // Signals to the original caller that the coroutine is finished
    done();
  }
}
