using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : EntityModel {
  // The direction the player is facing when the game starts
  public string intialDirection = "right";

  // The level the player will start in
  public int initialLevel = 0;

  // The list of initial positions the player takes in each level
  public List<Vector2> initialPositionList;

  // The amount of time for movement to be completed
  public float timeToMove = 0.2f;

  // The current level the player is in
  private int currentLevel;

  // The current position of the player in a level
  private Vector2 currentPosition;

  // Gets the level the player is currently in
  public int GetCurrentLevel() {
    return currentLevel;
  }

  // Get the current player position
  public Vector2 GetCurrentPosition() {
    return currentPosition;
  }

  // Updates the player's position in the model to one tile down
  public Vector2 MoverDown() {
    currentPosition += Vector2.down;
    return currentPosition;
  }

  // Updates the player's position in the model to one tile left
  public Vector2 MoveLeft() {
    currentPosition += Vector2.left;
    return currentPosition;
  }

  // Updates the player's position in the model to one tile right
  public Vector2 MoveRight() {
    currentPosition += Vector2.right;
    return currentPosition;
  }

  // Updates the player's position in the model to one tile up
  public Vector2 MoveUp() {
    currentPosition += Vector2.up;
    return currentPosition;
  }

  // Updates the level the player is in
  public int SetCurrentLevel(int nextLevel) {
    currentLevel = nextLevel;
    return currentLevel;
  }

  // Updates the player's position in the model to requested tile
  public Vector2 SetCurrentPosition(Vector2 nextPosition) {
    currentPosition = nextPosition;
    return currentPosition;    
  }
}
