using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridMovement : MonoBehaviour {
  private void validateMoveUp() {
    if (!isMoving) {
      StartCoroutine(MovePlayer(Vector3.up));
    }
  }

  private void validateMoveRight() {
    if (!isMoving) {
      StartCoroutine(MovePlayer(Vector3.right));
    }
  }

  private void validateMoveDown() {
    if (!isMoving) {
      StartCoroutine(MovePlayer(Vector3.down));
    }
  }

  private void validateMoveLeft() {
   if (!isMoving) {
      StartCoroutine(MovePlayer(Vector3.left));
    } 
  }

  private IEnumerator MovePlayer(Vector3 direction) {
    Vector3 positionOriginal = transform.position;
    Vector3 positionTarget = positionOriginal + direction;
    float timeElapsed = 0;

    while (timeElapsed < timeToMove) {
      transform.position = Vector3.Lerp(positionOriginal, positionTarget, timeElapsed / timeToMove);
      timeElapsed += Time.deltaTime;
      yield return null;
    }

    transform.position = positionTarget;

    // add reference to function in level controller
  }
}
