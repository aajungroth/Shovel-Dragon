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

  // The current position of the interactable
  private Vector2 positionCurrent;
}
