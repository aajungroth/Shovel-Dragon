using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour {
  // Starts the coroutine to move a GameObject down
  public void MoveGameObjectDown(Action done, GameObject targetGameObject, float timeToMove) {
    StartCoroutine(MoveGameObject(done, targetGameObject, timeToMove, Vector3.down));
  }

  // Starts the coroutine to move a GameObject left
  public void MoveGameObjectLeft(Action done, GameObject targetGameObject, float timeToMove) {
    StartCoroutine(MoveGameObject(done, targetGameObject, timeToMove, Vector3.left));
  }

  // Starts the coroutine to move a GameObject right
  public void MoveGameObjectRight(Action done, GameObject targetGameObject, float timeToMove) {
    StartCoroutine(MoveGameObject(done, targetGameObject, timeToMove, Vector3.right));
  }

  // Starts the coroutine to move a GameObject up
  public void MoveGameObjectUp(Action done, GameObject targetGameObject, float timeToMove) {
    StartCoroutine(MoveGameObject(done, targetGameObject, timeToMove, Vector3.up));
  }

  // Moves a GameObject in the requested time and diretion and signals when the movement is complete
  private IEnumerator MoveGameObject(Action done, GameObject targetGameObject, float timeToMove, Vector3 direction) {
    Vector3 originalPosition = targetGameObject.transform.position;
    Vector3 targetPosition = originalPosition + direction;
    float timeElapsed = 0;

    // This performs the movement across multiple frames
    while (timeElapsed < timeToMove) {
      targetGameObject.transform.position = Vector3
        .Lerp(originalPosition, targetPosition, timeElapsed / timeToMove);
      timeElapsed += Time.deltaTime;
      yield return null;
    }

    // Ensures the Game Object reaches the target position exactly
    targetGameObject.transform.position = targetPosition;

    // Signals to the original caller that the coroutine is finished
    done();
  }
}
