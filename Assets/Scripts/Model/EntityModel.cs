using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityModel : MonoBehaviour {
  // The direction the entity is facing when the game starts
  public string initialDirection = "right";

  // The level entity starts in
  public int initialLevel = 0;

  // The tile in the level that the entity starts on
  public Vector2 intialPosition;

  // The time it takes for movement to be completed
  public float timeToMove = 0.2f;

  // The direction the entity is currently facing
  private string currentDirection;

  // The level the entity is currently in
  private int currentLevel;

  // The current position of the entity
  private Vector2 currentPosition;

  // Awake is called before any other Start method
  void Awake() {
    // Set private variables based on initial data
    currentDirection = initialDirection;
    currentLevel = initialLevel;
    currentPosition = intialPosition;
  }

  // Gets the entity's current direction
  public string GetCurrentDirection() {
    return currentDirection;
  }

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
    currentDirection = "down";
    currentPosition += Vector2.down;
    return currentPosition;
  }

  // Updates the entity's position in the model left one tile
  public Vector2 MoveLeft() {
    currentDirection = "left";
    currentPosition += Vector2.left;
    return currentPosition;
  }

  // Updates the entity's position in the model right one tile
  public Vector2 MoveRight() {
    currentDirection = "right";
    currentPosition += Vector2.right;
    return currentPosition;
  }

  // Updates the entity's position in the model up one tile
  public Vector2 MoveUp() {
    currentDirection = "up";
    currentPosition += Vector2.up;
    return currentPosition;
  }

  // Updates the entity's direction
  public string SetCurrentDirection(string nextDirection) {
    currentDirection = nextDirection;
    return currentDirection;
  }

  // Updates the entity's level
  public int SetCurrentLevel(int nextLevel) {
    currentLevel = nextLevel;
    return currentLevel;
  }

  // Updates the entity's position in the model to a specific tile
  public Vector2 SetCurrentPosition(Vector2 nextPosition) {
    currentPosition = nextPosition;
    return currentPosition;
  }
}
