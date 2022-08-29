using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
  public float panDistance = 19;
  public float panTime = 1f;

  public void MoveCameraDown() {
    StartCoroutine(MoveCamera(Vector3.down * panDistance));
  }

  public void MoveCameraLeft() {
    StartCoroutine(MoveCamera(Vector3.left * panDistance));
  }

  public void MoveCameraRight() {
    StartCoroutine(MoveCamera(Vector3.right * panDistance));
  }

  public void MoveCameraUp() {
    StartCoroutine(MoveCamera(Vector3.up * panDistance));
  }

  private IEnumerator MoveCamera(Vector3 direction) {
    // The position the camera is moving to
    Vector3 targetPosition = transform.position + direction;

    // The time elapsed during the move
    float timeElapsed = 0;

    // This performs the movement over multiple frames
    while (timeElapsed < panTime) {
      transform.position = Vector3
        .MoveTowards(transform.position, targetPosition, timeElapsed / panTime);
      timeElapsed += Time.fixedDeltaTime;
      yield return null;
    }

    // Ensures the camera reaches the target position exactly
    transform.position = targetPosition;
  }
}
