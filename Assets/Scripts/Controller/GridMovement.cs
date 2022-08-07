using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour {
  // Starts the coroutine to move a transform down
  public void MoveTransformDown(Action done, Transform targetTransform, float timeToMove) {
    StartCoroutine(MoveTransform(done, targetTransform, timeToMove, Vector3.down));
  }

  // Starts the coroutine to move a transform left
  public void MoveTransformLeft(Action done, Transform targetTransform, float timeToMove) {
    StartCoroutine(MoveTransform(done, targetTransform, timeToMove, Vector3.left));
  }

  // Starts the coroutine to move a transform right
  public void MoveTransformRight(Action done, Transform targetTransform, float timeToMove) {
    StartCoroutine(MoveTransform(done, targetTransform, timeToMove, Vector3.right));
  }

  // Starts the coroutine to move a transform up
  public void MoveTransformUp(Action done, Transform targetTransform, float timeToMove) {
    StartCoroutine(MoveTransform(done, targetTransform, timeToMove, Vector3.up));
  }

  // Moves a transform in the requested time and direction and signals when the movement is complete
  private IEnumerator MoveTransform(Action done, Transform targetTransform, float timeToMove, Vector3 direction) {
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

    // Ensures the Game Object reaches the target position exactly
    targetTransform.position = targetPosition;

    // Signals to the original caller that the coroutine is finished
    done();
  }
}
