using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterModel : EntityModel {
  // The starting position of the monster
  public Vector2 initialPosition;

  // Tests if the monster has been buried
  public bool isBuried = false;

  // The name of the monster's AI script
  public string monsterAI;
}
