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

  }
}
