using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAI : MonoBehaviour {
  public virtual Vector2 GetMove(string ability, EntityModel entity, List<GameObject> entityList, TrackModel trackModel) {
    return Vector2.zero;
  }
}
