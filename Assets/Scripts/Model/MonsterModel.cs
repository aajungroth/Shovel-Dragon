using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterModel : EntityModel {
  // The starting position of the interactable
  public Vector2 initialPosition;

  // Tests if the monster has been buried
  public bool isBuried = false;

  // The name of the interactable's AI script if it is a monster
  public string monsterAI;
}
