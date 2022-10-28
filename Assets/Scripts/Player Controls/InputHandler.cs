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

  // The name of the trigger fo the player's jump animation
  const string jumpTrigger = "Jump";

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

  // Tests that the previous move and animation have completed
  private bool isStationary() {
    // Gets the normalized time to determine if a loop of the animation has completed
    float normalizedTimeInfo = playerAninmator
      .GetCurrentAnimatorStateInfo(0).normalizedTime;

    return isInputEnabled && normalizedTimeInfo > 1;
  }

  // Asks the level controller to move the player down
  private void RequestMoveDown() {
    if (isStationary()) {
      playerAninmator.SetTrigger(jumpTrigger);
      isInputEnabled = false;
      levelController.HandleMoveDown(EnableInput);
    }
  }

  // Asks the level controller to move the player left
  private void RequestMoveLeft() {
    if (isStationary()) {
      playerAninmator.SetTrigger(jumpTrigger);
      isInputEnabled = false;
      levelController.HandleMoveLeft(EnableInput);
    } 
  }

  // Asks the level controller to move the player right
  private void RequestMoveRight() {
    if (isStationary()) {
      playerAninmator.SetTrigger(jumpTrigger);
      isInputEnabled = false;
      levelController.HandleMoveRight(EnableInput);
    }
  }

  // Asks the level controller to move the player up
  private void RequestMoveUp() {
    if (isStationary()) {
      playerAninmator.SetTrigger(jumpTrigger);
      isInputEnabled = false;
      levelController.HandleMoveUp(EnableInput);
    }
  }
}
