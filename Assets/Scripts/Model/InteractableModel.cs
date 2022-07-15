using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableModel : MonoBehaviour {
  // Defines how the interactable's current state in a level
  public bool isActive = true;
  public bool isBuried = false;

  // Defines the interactable's type
  public bool isDoor = false;
  public bool isKey = false;
  public bool isMonster = false;
  public bool isPowerUp = false;

  // The name of the interactables AI script if it is a monster
  public string monsterAI;

  // The starting position of the interactable
  public Vector2 positionStart;

  // The time it takes for movement to be completed
  public float timeToMove = 0.2f;

  // The current position of the interactable
  private Vector2 positionCurrent;

  // Gets the interactables current position
  public Vector2 GetPositionCurrent() {
    return positionCurrent;
  }

  // Updates the interactable's position in the model down one tile
  public Vector2 MovePositionCurrentDown() {
    positionCurrent += Vector2.down;
    return positionCurrent;
  }

  // Updates the interactable's position in the model left one tile
  public Vector2 MovePositionCurrentLeft() {
    positionCurrent += Vector2.left;
    return positionCurrent;
  }

  // Updates the interactable's position in the model right one tile
  public Vector2 MovePositionCurrentRight() {
    positionCurrent += Vector2.right;
    return positionCurrent;
  }

  // Updates the interactable's position in the model up one tile
  public Vector2 MovePositionCurrentUp() {
    positionCurrent += Vector2.up;
    return positionCurrent;
  }

  // Updates the interactable's position in the model to a specific tile
  public Vector2 SetPositionCurrent(Vector2 positionNext) {
    positionCurrent = positionNext;
    return positionNext;
  }
}
