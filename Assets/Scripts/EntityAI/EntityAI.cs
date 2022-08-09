using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAI : MonoBehaviour {
  public virtual EventModel GetEvent(GameObject entity, EventModel entityEvent,
  List<GameObject> entityList, string playerAbility, Vector2 playerDirection,
  TrackModel trackModel) {
    // Returns a default entity with the associated EntityModel
    entityEvent.entity = entity;

    return entityEvent;
  }
}
