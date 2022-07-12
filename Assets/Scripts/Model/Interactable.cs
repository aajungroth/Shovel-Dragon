using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
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

  // Moves the interactable down one tile
  public void moveDown() {
    return StartCoroutine(move(Vector3.down));
  }

  // Moves the interactable left one tile
  public void moveLeft() {
    return StartCoroutine(move(Vector3.left));
  }

  // Moves the interactable right one tile
  public void moveRight() {
    return StartCoroutine(move(Vector3.right));
  }

  // Moves the interactable up one tile
  public void moveUp() {
    return StartCoroutine(move(Vector3.up));
  }

  // Moves the interactable in a given direction
  private IEnumerator move(direction) {

  }
}
