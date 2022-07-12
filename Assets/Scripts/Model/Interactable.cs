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
    StartCoroutine(move(Vector3.down));
  }

  // Moves the interactable left one tile
  public void moveLeft() {
    StartCoroutine(move(Vector3.left));
  }

  // Moves the interactable right one tile
  public void moveRight() {
    StartCoroutine(move(Vector3.right));
  }

  // Moves the interactable up one tile
  public void moveUp() {
    StartCoroutine(move(Vector3.up));
  }

  // Moves the interactable in a given direction
  private IEnumerator move(Vector3 direction) {
    Vector3 positionOriginal = transform.position;
    Vector3 positionTarget = positionOriginal + direction;
    float timeElapsed = 0;

    while (timeElapsed < timeToMove) {
      transform.position = Vector3.Lerp(positionOriginal, positionTarget, timeElapsed / timeToMove);
      timeElapsed += Time.deltaTime;
      yield return null;
    }

    transform.position = positionTarget;
  }
}
