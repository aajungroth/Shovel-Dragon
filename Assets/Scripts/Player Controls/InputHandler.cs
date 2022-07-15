using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour {
  // The buttons used to control movement
  public Button buttonDown;
  public Button buttonLeft;
  public Button buttonRight;
  public Button buttonUp;

  // Only one button input will be processed at a time
  public bool isInputEnabled = true;

  // Start is called before the first frame update
  void Start() {
    buttonDown.onClick.AddListener(requestMoveDown);
    buttonLeft.onClick.AddListener(requestMoveLeft);
    buttonRight.onClick.AddListener(requestMoveRight);
    buttonUp.onClick.AddListener(requestMoveUp);
  }

  // Asks the level controller to move the player down
  private void requestMoveDown() {
    if (isInputEnabled) {
      isInputEnabled = false;
      // level controller function
    }
  }

  // Asks the level controller to move the player left
  private void requestMoveLeft() {
   if (isInputEnabled) {
      isInputEnabled = false;
      // level controller function
    } 
  }

  // Asks the level controller to move the player right
  private void requestMoveRight() {
    if (isInputEnabled) {
      isInputEnabled = false;
      // level controller function
    }
  }

  // Asks the level controller to move the player up
  private void requestMoveUp() {
    if (isInputEnabled) {
      isInputEnabled = false;
      // level controller function
    }
  }
}
