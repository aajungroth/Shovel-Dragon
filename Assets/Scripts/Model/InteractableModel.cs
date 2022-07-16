using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableModel : MonoBehaviour {
  // The level interactabl starts in
  public int initialLevel = 0;

  // The starting position of the interactable
  public Vector2 initialPosition;

  // Defines how the interactable's current state in a level
  public bool isActive = true;
  public bool isBuried = false;

  // Defines the interactable's type
  public bool isDoor = false;
  public bool isKey = false;
  public bool isMonster = false;
  public bool isPowerUp = false;

  // The name of the interactable's AI script if it is a monster
  public string monsterAI;

  // The time it takes for movement to be completed
  public float timeToMove = 0.2f;

  // The level the interactable is currently in
  private int currentLevel;

  // The current position of the interactable
  private Vector2 currentPosition;

  // Gets the interactable's current level
  public int GetCurrentLevel() {
    return currentLevel;
  }

  // Gets the interactable's current position
  public Vector2 GetCurrentPosition() {
    return currentPosition;
  }

  // Updates the interactable's position in the model down one tile
  public Vector2 MoveDown() {
    currentPosition += Vector2.down;
    return currentPosition;
  }

  // Updates the interactable's position in the model left one tile
  public Vector2 MoveLeft() {
    currentPosition += Vector2.left;
    return currentPosition;
  }

  // Updates the interactable's position in the model right one tile
  public Vector2 MoveRight() {
    currentPosition += Vector2.right;
    return currentPosition;
  }

  // Updates the interactable's position in the model up one tile
  public Vector2 MoveUp() {
    currentPosition += Vector2.up;
    return currentPosition;
  }

  // Updates the interactable's level
  public int SetCurrentLevel(int nextLevel) {
    currentLevel = nextLevel;
    return currentLevel;
  }

  // Updates the interactable's position in the model to a specific tile
  public Vector2 SetCurrentPosition(Vector2 positionNext) {
    currentPosition = positionNext;
    return currentPosition;
  }
}
