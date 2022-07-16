using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityModel : MonoBehaviour {
  // The level entity starts in
  public int initialLevel = 0;

  // The starting position of the entity
  public Vector2 initialPosition;

  // The time it takes for movement to be completed
  public float timeToMove = 0.2f;

  // The level the entity is currently in
  private int currentLevel;

  // The current position of the entity
  private Vector2 currentPosition;

  // Gets the entity's current level
  public int GetCurrentLevel() {
    return currentLevel;
  }

  // Gets the entity's current position
  public Vector2 GetCurrentPosition() {
    return currentPosition;
  }

  // Updates the entity's position in the model down one tile
  public Vector2 MoveDown() {
    currentPosition += Vector2.down;
    return currentPosition;
  }

  // Updates the entity's position in the model left one tile
  public Vector2 MoveLeft() {
    currentPosition += Vector2.left;
    return currentPosition;
  }

  // Updates the entity's position in the model right one tile
  public Vector2 MoveRight() {
    currentPosition += Vector2.right;
    return currentPosition;
  }

  // Updates the entity's position in the model up one tile
  public Vector2 MoveUp() {
    currentPosition += Vector2.up;
    return currentPosition;
  }

  // Updates the entity's level
  public int SetCurrentLevel(int nextLevel) {
    currentLevel = nextLevel;
    return currentLevel;
  }

  // Updates the entity's position in the model to a specific tile
  public Vector2 SetCurrentPosition(Vector2 positionNext) {
    currentPosition = positionNext;
    return currentPosition;
  }
}
