using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidGridMovement : MonoBehaviour {
  // Starts the coroutine to feint a transform down
  public void FeintTransformDown(Action done, Transform targetTransform, float timeToMove) {
    StartCoroutine(FeintTransform(done, targetTransform, timeToMove, Vector3.down));
  }

  // Starts the coroutine to feint a transform left
  public void FeintTransformLeft(Action done, Transform targetTransform, float timeToMove) {
    StartCoroutine(FeintTransform(done, targetTransform, timeToMove, Vector3.left));
  }

  // Starts the coroutine to feint a transform right
  public void FeintTransformRight(Action done, Transform targetTransform, float timeToMove) {
    StartCoroutine(FeintTransform(done, targetTransform, timeToMove, Vector3.right));
  }

  // Starts the coroutine to feint a transform up
  public void FeintTransformUp(Action done, Transform targetTransform, float timeToMove) {
    StartCoroutine(FeintTransform(done, targetTransform, timeToMove, Vector3.up));
  }

  // Feints a transform in the requested time and direction and signals when the movement is complete
  private IEnumerator FeintTransform(Action done, Transform targetTransform, float timeToMove, Vector3 direction) {
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
