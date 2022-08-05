using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyModel : EntityModel {
  // Tests if the key has been buried
  public bool isBuried = true;

  // Tests if the key is following an entity
  public bool isFollowing = false;

  // The name of what the key is following
  // ie none, player, or MonsterAI names
  public string leader = none;
}
