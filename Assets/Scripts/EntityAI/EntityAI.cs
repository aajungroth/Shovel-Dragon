using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAI : MonoBehaviour {
  // Idles the entity
  public virtual (string, Vector2) GetEvent(GameObject entity,
  List<GameObject> entityList, string playerAbility, Vector2 playerDirection,
  TrackModel trackModel) {
    return (AbilityModel.none, Vector2.zero);
  }
}
