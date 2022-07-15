using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
  // The buttons used to control movement
  public Button buttonUp;
  public Button buttonRight;
  public Button buttonDown;
  public Button buttonLeft;

  // Only one button input will be processed at a time
  public bool isInputEnabled = true;

  // Start is called before the first frame update
  void Start() {
    buttonUp.onClick.AddListener(validateMoveUp);
    buttonRight.onClick.AddListener(validateMoveRight);
    buttonDown.onClick.AddListener(validateMoveDown);
    buttonLeft.onClick.AddListener(validateMoveLeft);
  }

  private void requestMoveUp() {
    if (isInputEnabled) {
      isInputEnabled = false;
      // level controller function
    }
  }

  private void requestMoveRight() {
    if (isInputEnabled) {
      isInputEnabled = false;
      // level controller function
    }
  }

  private void requestMoveDown() {
    if (isInputEnabled) {
      isInputEnabled = false;
      // level controller function
    }
  }

  private void requestMoveLeft() {
   if (isInputEnabled) {
      isInputEnabled = false;
      // level controller function
    } 
  }
}
