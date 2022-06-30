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
  private string monsterAI;
}
