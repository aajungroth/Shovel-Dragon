using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : EntityAI {
  // Moves the entity based on player input
  public override (string, Vector2) GetEvent(GameObject entity,
  List<GameObject> entityList, string playerAbility, Vector2 playerDirection,
  TrackModel trackModel) {
    return (playerAbility, playerDirection);
  }
}
