using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : EntityAI {
  public override EventModel GetEvent(GameObject entity, EventModel entityEvent,
  List<GameObject> entityList, string playerAbility, Vector2 playerDirection,
  TrackModel trackModel) {
    entityEvent.ability = playerAbility;
    entityEvent.direction = playerDirection;
    entityEvent.endPosition = entityEvent.startPosition + playerDirection;
    entityEvent.entity = entity;

    return entityEvent;
  }
}
