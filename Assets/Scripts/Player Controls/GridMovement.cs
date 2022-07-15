using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour {
  public void MoveGameObjectUp() {
    StartCoroutine(MoveGameObject(Vector3.up));
  }

  public void MoveGameObjectRight() {
    StartCoroutine(MoveGameObject(Vector3.right));
  }

  public void MoveGameObjectDown() {
    StartCoroutine(MoveGameObject(Vector3.down));
  }

  public void MoveGameObjectLeft() {
    StartCoroutine(MoveGameObject(Vector3.left));
  }

  private IEnumerator MoveGameObject(Action done, GameObject targetGameObject, Vector3 direction) {
    Vector3 positionOriginal = targetGameObject.transform.position;
    Vector3 positionTarget = positionOriginal + direction;
    float timeElapsed = 0;

    while (timeElapsed < timeToMove) {
      targetGameObject.transform.position = Vector3
        .Lerp(positionOriginal, positionTarget, timeElapsed / timeToMove);
      timeElapsed += Time.deltaTime;
      yield return null;
    }

    transform.position = positionTarget;

    done();
  }
}
