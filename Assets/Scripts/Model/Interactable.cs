using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
  // Defines the interactable's type
  public bool isDoor = false;
  public bool isKey = false;
  public bool isMonster = false;
  public bool isPowerUp = false;

  // Holds the name of the interactables AI script if it is a monster
  public string monsterAI;

  // Holds the starting position of the interactable
  public Vector2 positionStart;

  // Holds the current position of the interactable
  private Vector2 positionCurrent;
}
