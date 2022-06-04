using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridMovement : MonoBehaviour {
  public Button buttonUp;
  public Button buttonRight;
  public Button buttonDown;
  public Button buttonLeft;
  public float timeToMove = 0.2f;

  private bool isMoving = false;
  private Vector3 positionOriginal = Vector3.zero;
  private Vector3 positionTarget = Vector3.zero;

  // Start is called before the first frame update
  void Start() {
    buttonUp.onClick.AddListener(validateMove, Vector3.up);
    buttonRight.onClick.AddListener(validateMove, Vector3.right);
    buttonDown.onClick.AddListener(validateMove, Vector3.down);
    buttonLeft.onClick.AddListener(validateMove, Vector3.left);
  }

  // Update is called once per frame
  void Update() {
    
  }
  
  private void validateMove(Vector3 direction) {  
    if (!isMoving && direction == up) {
      StartCoroutine(MovePlayer(Vector3.up));
    }
    else if (!isMoving && direction == right) {
      StartCoroutine(MovePlayer(Vector3.right));
    }
    else if (!isMoving && direction == down) {
      StartCoroutine(MovePlayer(Vector3.down));
    }
    else if (!isMoving && direction == left) {
      StartCoroutine(MovePlayer(Vector3.left));
    }
  }

  private IEnumerator MovePlayer(Vector3 direction) {
    isMoving = true;

    float timeElapsed = 0;

    positionOriginal = transform.position;
    positionTarget = positionOriginal + direction;

    while (timeElapsed < timeToMove) {
      transform.position = Vector3.Lerp(positionOriginal, positionTarget, timeElapsed / timeToMove);
      timeElapsed += Time.deltaTime;
      yield return null;
    }

    transform.position = positionTarget;

    isMoving = false;
  }
}
