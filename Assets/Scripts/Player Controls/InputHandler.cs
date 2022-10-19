using System;
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

  // Updates the model and view based on player input and detects collisions
  public LevelController levelController;

  // Used to trigger animations for the player
  public Animator playerAninmator;

  // Start is called before the first frame update
  void Start() {
    buttonDown.onClick.AddListener(RequestMoveDown);
    buttonLeft.onClick.AddListener(RequestMoveLeft);
    buttonRight.onClick.AddListener(RequestMoveRight);
    buttonUp.onClick.AddListener(RequestMoveUp);
  }

  // Enables player input
  private void EnableInput() {
    isInputEnabled = true;
  }

  // Asks the level controller to move the player down
  private void RequestMoveDown() {
    if (isInputEnabled) {
      isInputEnabled = false;
      levelController.HandleMoveDown(EnableInput);
    }
  }

  // Asks the level controller to move the player left
  private void RequestMoveLeft() {
   if (isInputEnabled) {
      isInputEnabled = false;
      levelController.HandleMoveLeft(EnableInput);
    } 
  }

  // Asks the level controller to move the player right
  private void RequestMoveRight() {
    if (isInputEnabled) {
      playerAninmator.SetTrigger("Jump");
      isInputEnabled = false;
      levelController.HandleMoveRight(EnableInput);
    }
  }

  // Asks the level controller to move the player up
  private void RequestMoveUp() {
    if (isInputEnabled) {
      isInputEnabled = false;
      levelController.HandleMoveUp(EnableInput);
    }
  }
}
