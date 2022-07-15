using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableModel : MonoBehaviour {
  // The level interactabl starts in
  public int initialLevel = 0;

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
  public Vector2 startPosition;

  // The time it takes for movement to be completed
  public float timeToMove = 0.2f;

  // The level the interactable is currently in
  private int currentLevel;

  // The current position of the interactable
  private Vector2 currentPosition;

  // Gets the interactables current position
  public Vector2 GetCurrentPosition() {
    return currentPosition;
  }

  // Updates the interactable's position in the model down one tile
  public Vector2 MoveCurrentPositionDown() {
    currentPosition += Vector2.down;
    return currentPosition;
  }

  // Updates the interactable's position in the model left one tile
  public Vector2 MoveCurrentPositionLeft() {
    currentPosition += Vector2.left;
    return currentPosition;
  }

  // Updates the interactable's position in the model right one tile
  public Vector2 MoveCurrentPositionRight() {
    currentPosition += Vector2.right;
    return currentPosition;
  }

  // Updates the interactable's position in the model up one tile
  public Vector2 MoveCurrentPositionUp() {
    currentPosition += Vector2.up;
    return currentPosition;
  }

  // Updates the interactable's position in the model to a specific tile
  public Vector2 SetCurrentPosition(Vector2 positionNext) {
    currentPosition = positionNext;
    return currentPosition;
  }
}
