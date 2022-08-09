using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAI : MonoBehaviour {
  public virtual Vector2 GetDirection(string ability, GameObject entity,
  List<GameObject> entityList, TrackModel trackModel) {
    return Vector2.zero;
  }
}
