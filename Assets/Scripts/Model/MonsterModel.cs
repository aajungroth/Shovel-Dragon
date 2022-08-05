using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterModel : EntityModel {
  // The list of unique entities following the monster
  public List<string> followerList;

  // Tests if the monster has been buried
  public bool isBuried = false;

  // The name of the monster's AI script
  public string monsterAI;
}
