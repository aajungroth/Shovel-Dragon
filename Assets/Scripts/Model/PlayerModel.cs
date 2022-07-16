using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {
  public string intialPlayerDirection = "right";
  public int initialPlayerLevel = 0;

  // The list of initial positions the player takes in each level
  public List<Vector2> initialPlayerPositionList;

  // The current position of the player in a level
  private Vector2 currentPlayerPosition;

  // Get the current player position
  public Vector2 GetCurrentPlayerPosition() {
    return currentPlayerPosition;
  }

  // Updates the player's position in the model to one tile down
  public Vector2 MovePlayerDown() {
    currentPlayerPosition += Vector2.down;
    return currentPlayerPosition;
  }

  // Updates the player's position in the model to one tile left
  public Vector2 MovePlayerLeft() {
    currentPlayerPosition += Vector2.left;
    return currentPlayerPosition;
  }

  // Updates the player's position in the model to one tile right
  public Vector2 MovePlayerRight() {
    currentPlayerPosition += Vector2.right;
    return currentPlayerPosition;
  }

  // Updates the player's position in the model to one tile up
  public Vector2 MovePlayerUp() {
    currentPlayerPosition += Vector2.up;
    return currentPlayerPosition;
  }

  // Updates the player's position in the model to requested tile
  public Vector2 SetCurrentPlayerPosition(Vector2 nextPlayerPosition) {
    currentPlayerPosition = nextPlayerPosition;
    return currentPlayerPosition;    
  }
}
