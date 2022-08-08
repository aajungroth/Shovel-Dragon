using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovementAI : MonsterAI {
  public override Vector2 GetMove(List<EntityModel> entityList, TrackModel trackModel, EntityModel entity) {
    return Vector2.zero;
	}
}
